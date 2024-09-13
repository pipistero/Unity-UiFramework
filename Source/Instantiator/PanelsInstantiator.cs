using System;
using PS.UiFramework.Attributes;
using PS.UiFramework.Container;
using PS.UiFramework.Panels;
using PS.UiFramework.PrefabProvider;
using PS.UiFramework.Provider;
using PS.UiFramework.Widgets;
using Zenject;
using Object = UnityEngine.Object;

namespace PS.UiFramework.Instantiator
{
    /// <inheritdoc />
    public sealed class PanelsInstantiator : IPanelsInstantiator
    {
        private readonly IPanelPrefabProvider _panelPrefabProvider;
        private readonly PanelsContainerProxy _panelsContainerProxy;
        private readonly IPanelsProvider _panelsProvider;
        private readonly IInstantiator _instantiator;

        public PanelsInstantiator(
            IPanelPrefabProvider panelPrefabProvider, 
            PanelsContainerProxy panelsContainerProxy, 
            IPanelsProvider panelsProvider, 
            IInstantiator instantiator)
        {
            _panelPrefabProvider = panelPrefabProvider;
            _panelsContainerProxy = panelsContainerProxy;
            _panelsProvider = panelsProvider;
            _instantiator = instantiator;
        }

        /// <inheritdoc />
        public void CreateAndRegisterPanel<TPanel>() where TPanel : APanel
        {
            if (_panelPrefabProvider.TryGet(out TPanel panelPrefab) == false)
                throw new Exception($"[{nameof(IPanelPrefabProvider)}] | Not found panel prefab with type {typeof(TPanel).Name}");

            var panel = CreatePanel(panelPrefab);
            var panelWidgets = GetWidgetViews(panel);

            InjectAndInitializeViewModels(panelWidgets);
            InitializePanel(panel);
            
            _panelsProvider.RegisterPanel(panel);
        }

        /// <inheritdoc />
        public void DestroyAndUnregisterPanel<TPanel>() where TPanel : APanel
        {
            if (_panelsProvider.TryGetPanel<TPanel>(out var panel) == false)
                throw new Exception($"[{nameof(IPanelPrefabProvider)}] | panel with type {typeof(TPanel).Name} is not registered");

            _panelsProvider.UnregisterPanel<TPanel>();

            Object.Destroy(panel.gameObject);
        }
        
        private TPanel CreatePanel<TPanel>(TPanel panelPrefab) where TPanel : APanel
        {
            var sceneObject = _instantiator.InstantiatePrefab(panelPrefab, _panelsContainerProxy.Container.transform);
            var panel = sceneObject.GetComponent<TPanel>();
            return panel;
        }

        private void InjectAndInitializeViewModels(IWidgetView[] widgetViews)
        {
            foreach (var widgetView in widgetViews)
            {
                var viewModel = widgetView.InjectViewModel(_instantiator);
                
                if (viewModel is IWidgetViewModelInitializable initializableViewModel)
                    initializableViewModel.Initialize();
            }
        }

        private static IWidgetView[] GetWidgetViews(APanel panel)
        {
            return panel.GetComponentsInChildren<IWidgetView>();
        }

        private static void InitializePanel(APanel panel)
        {
            panel.Initialize();
            panel.CloseImmediately();
                
            if (panel is IPanelInitializable initializablePanel)
                initializablePanel.OnInitialize();
        }
    }
}