using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using PS.UiFramework.Animations;
using PS.UiFramework.Source.Editor;
using UnityEngine;

namespace PS.UiFramework.Panels.Components
{
#if UNITY_EDITOR
    [RequireComponent(typeof(PanelAnimatorInspector))]
#endif
    public class PanelAnimator : MonoBehaviour, IPanelComponent
    {
        [field: Header("Settings")] 
        [field: SerializeField] public float UnblockRaycastDelayOnOpen { get; private set; }
        
        private PanelRoot _panelRoot;
        
        private APanelAnimation[] _animations;

        private bool _isInitialized;
        
        internal void Initialize(PanelRoot panelRoot)
        {
            _panelRoot = panelRoot;
            _animations = GetComponents<APanelAnimation>();
            
            _isInitialized = true;
        }

        internal async UniTask AnimateAsync(EAnimationType animationType)
        {
            ValidateInitialization();
            
            var animationTasks = _animations
                .Where(a => a.IsEnabled && a.Type == animationType)
                .Select(a => a.animateAsync(_panelRoot.CanvasGroup, _panelRoot.RectTransform));
            
            await UniTask.WhenAll(animationTasks);
        }
        
        private void ValidateInitialization()
        {
            if (!_isInitialized)
                throw new Exception("PanelAnimator is not initialized");
        }
    }
}