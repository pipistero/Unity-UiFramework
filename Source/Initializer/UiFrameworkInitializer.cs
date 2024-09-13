using PS.UiFramework.Container;
using Zenject;

namespace PS.UiFramework.Initializer
{
    /// <inheritdoc />
    public sealed class UiFrameworkInitializer : IUiFrameworkInitializer
    {
        [Inject] private PanelsContainerProxy _panelsContainerProxy;
        
        /// <inheritdoc />
        public void Initialize()
        {
            _panelsContainerProxy.Initialize();
        }
    }
}