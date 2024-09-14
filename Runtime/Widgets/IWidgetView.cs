using Cysharp.Threading.Tasks;
using PS.UiFramework.Animations;

namespace PS.UiFramework.Widgets
{
    /// <summary>
    /// Defines the basic operations for widget views.
    /// </summary>
    public interface IWidgetView
    {
        /// <summary>
        /// Initializes the widget view, setting up necessary components and state.
        /// </summary>
        void Initialize();
        
        /// <summary>
        /// Subscribes to relevant events or services.
        /// </summary>
        void Subscribe();

        UniTask AnimateAsync(EAnimationType animationType);
    }
}