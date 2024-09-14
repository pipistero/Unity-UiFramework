using Cysharp.Threading.Tasks;
using PS.UiFramework.Controller.Layers;
using PS.UiFramework.Panels;
using PS.UiFramework.Provider;

namespace PS.UiFramework.Controller
{
    /// <inheritdoc cref="IPanelsController"/>
    public sealed class PanelsController : IPanelsController
    {
        private readonly IPanelsProvider _panelsProvider;
        private readonly IPanelsLayersController _layersController;

        public PanelsController(IPanelsProvider panelsProvider, IPanelsLayersController layersController)
        {
            _panelsProvider = panelsProvider;
            _layersController = layersController;
        }

        /// <inheritdoc />
        public async UniTask Open<TPanel>() where TPanel : APanel
        {
            if (_panelsProvider.TryGetPanel<TPanel>(out var panelToOpen) == false)
                return;

            if (panelToOpen.State is EPanelState.Open or EPanelState.InOpenAnimation)
                return;

            _layersController.SetPanelLayer(panelToOpen);

            await panelToOpen.Open();
        }

        /// <inheritdoc />
        public async UniTask OpenExtraordinary<TPanel>(int sortingOrder = 32767) where TPanel : APanel
        {
            if (_panelsProvider.TryGetPanel<TPanel>(out var panelToOpen) == false)
                return;

            if (panelToOpen.State is EPanelState.Open or EPanelState.InOpenAnimation)
                return;
            
            panelToOpen.SortingOrder = sortingOrder;
            
            await panelToOpen.Open();
        }

        /// <inheritdoc />
        public async UniTask Toggle<TPanel>() where TPanel : APanel
        {
            if (_panelsProvider.TryGetPanel<TPanel>(out var panelToToggle) == false)
                return;

            switch (panelToToggle.State)
            {
                case EPanelState.Open:
                    await Close<TPanel>();
                    break;
                case EPanelState.Close:
                    await Open<TPanel>();
                    break;
            }
        }
        
        /// <inheritdoc />
        public async UniTask Close<TPanel>() where TPanel : APanel
        {
            if (_panelsProvider.TryGetPanel<TPanel>(out var panelToClose) == false)
                return;

            if (panelToClose.State is EPanelState.Close or EPanelState.InCloseAnimation)
                return;

            await panelToClose.Close();
            
            _layersController.PanelClosed(panelToClose);
        }
    }
}