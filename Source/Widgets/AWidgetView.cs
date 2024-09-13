using System;
using Cysharp.Threading.Tasks;
using PS.UiFramework.Animations;
using PS.UiFramework.Attributes;
using PS.UiFramework.Source.Editor;
using PS.UiFramework.Unsubscribe;
using PS.UiFramework.Widgets.Components;
using UnityEngine;

namespace PS.UiFramework.Widgets
{
    /// <summary>
    /// Represents a base class for widget views that interacts with a view model.
    /// </summary>
    /// <typeparam name="TViewModel">The type of view model used by this widget view, which must implement <see cref="IWidgetViewModel"/>.</typeparam>
#if UNITY_EDITOR
    [RequireComponent(typeof(WidgetInspector))]
#endif
    public abstract class AWidgetView<TViewModel> : MonoBehaviour, IWidgetView
        where TViewModel : IWidgetViewModel
    {
        /// <summary>
        /// The view model associated with this widget view. Injected automatically.
        /// </summary>
        [InjectViewModel] protected TViewModel _viewModel;

        private WidgetAnimator _animator;

        private bool _isInitialized;
        
        /// <inheritdoc />
        public void Initialize()
        {
            var animations = GetComponents<AWidgetAnimation>();
            _animator = new WidgetAnimator(animations);
            
            _isInitialized = true;
        }
        
        /// <inheritdoc />
        public void Subscribe() => Subscribe(new UnsubscribeLink(gameObject));
        
        /// <summary>
        /// Subscribes to relevant events or services using the specified unsubscribe link.
        /// </summary>
        /// <param name="unsubscribeLink">The link used to unsubscribe from events or services.</param>
        protected abstract void Subscribe(UnsubscribeLink unsubscribeLink);
        
        public async UniTask AnimateAsync(EAnimationType animationType)
        {
            ValidateInitialization();
            await _animator.AnimateAsync(animationType);
        }

        private void ValidateInitialization()
        {
            if (_isInitialized == false)
                throw new Exception($"WidgetView ({typeof(TViewModel).Name}) is not initialized");
        }
    }
}