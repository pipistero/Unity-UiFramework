using System;
using Cysharp.Threading.Tasks;
using PS.UiFramework.Animations;
using PS.UiFramework.Extensions;
using PS.UiFramework.Panels.Components;
using PS.UiFramework.Source.Editor;
using PS.UiFramework.StaticData;
using UnityEngine;

namespace PS.UiFramework.Panels
{
    /// <summary>
    /// Represents a base class for UI panels in the framework.
    /// </summary>
#if UNITY_EDITOR
    [RequireComponent(typeof(PanelInspector))]
#endif
    public abstract class APanel : MonoBehaviour
    {
        public EPanelState State { get; private set; }

        public int SortingOrder
        {
            get => _panelRoot.Canvas.sortingOrder;
            internal set => _panelRoot.Canvas.sortingOrder = value;
        }

        private PanelRoot _panelRoot;
        private PanelAnimator _panelAnimator;
        private PanelWidgets _panelWidgets;

        internal void Initialize()
        {
            InitializeComponents();
            
            _panelAnimator.Initialize(_panelRoot);
            _panelWidgets.Initialize();
        }

        private void InitializeComponents()
        {
            _panelRoot = this.EnsurePanelComponentCreated<PanelRoot>(PanelComponentNames.PANEL_ROOT_OBJECT_NAME);
            _panelAnimator = this.EnsurePanelComponentCreated<PanelAnimator>(PanelComponentNames.PANEL_ANIMATOR_OBJECT_NAME);
            _panelWidgets = new PanelWidgets(this);

            _panelRoot.Canvas.overrideSorting = true;
            _panelRoot.Canvas.vertexColorAlwaysGammaSpace = true;
        }

        internal async UniTask Open()
        {
            State = EPanelState.InOpenAnimation;
            
            gameObject.SetActive(true);

            await UniTask.WhenAll(
                UnblockRaycast(),
                PlayPanelAnimations(), 
                PlayWidgetsAnimations());
            
            State = EPanelState.Open;
            
            return;

            async UniTask PlayPanelAnimations()
            {
                await _panelAnimator.AnimateAsync(EAnimationType.OnOpen);
                _panelRoot.CanvasGroup.alpha = 1f;
            }

            async UniTask PlayWidgetsAnimations()
            {
                await _panelWidgets.AnimateAsync(EAnimationType.OnOpen);
            }
        }

        internal async UniTask Close()
        {
            State = EPanelState.InCloseAnimation;
            
            _panelRoot.CanvasGroup.interactable = false;
            
            await UniTask.WhenAll(
                _panelAnimator.AnimateAsync(EAnimationType.OnClose), 
                _panelWidgets.AnimateAsync(EAnimationType.OnClose));
            
            _panelRoot.CanvasGroup.alpha = 0f;
            gameObject.SetActive(false);

            State = EPanelState.Close;
        }

        internal void CloseImmediately()
        {
            _panelRoot.CanvasGroup.interactable = false;
            _panelRoot.CanvasGroup.alpha = 0f;
            gameObject.SetActive(false);

            State = EPanelState.Close;
        }
        
        private async UniTask UnblockRaycast()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_panelAnimator.UnblockRaycastDelayOnOpen));
            _panelRoot.CanvasGroup.interactable = true;
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _panelRoot = this.EnsurePanelComponentCreated<PanelRoot>(PanelComponentNames.PANEL_ROOT_OBJECT_NAME);
            _panelAnimator = this.EnsurePanelComponentCreated<PanelAnimator>(PanelComponentNames.PANEL_ANIMATOR_OBJECT_NAME);
        }
#endif
    }
}