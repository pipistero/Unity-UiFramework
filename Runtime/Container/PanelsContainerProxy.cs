using PS.UiFramework.Config;
using Zenject;

namespace PS.UiFramework.Container
{
    public sealed class PanelsContainerProxy : IPanelsContainerProxy
    {
        public PanelsContainer Container { get; private set; }

        private readonly IUiFrameworkConfig _config;
        private readonly IInstantiator _instantiator;

        public PanelsContainerProxy(IUiFrameworkConfig config, IInstantiator instantiator)
        {
            _config = config;
            _instantiator = instantiator;
        }

        internal void Initialize()
        {
            var sceneObject = _instantiator.InstantiatePrefab(_config.ContainerPrefab);
            sceneObject.transform.SetParent(null);
            Container = sceneObject.GetComponent<PanelsContainer>();
        }
    }
}