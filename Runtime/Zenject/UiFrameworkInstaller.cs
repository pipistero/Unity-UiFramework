using PS.UiFramework.Container;
using PS.UiFramework.Controller;
using PS.UiFramework.Controller.Layers;
using PS.UiFramework.Initializer;
using PS.UiFramework.Instantiator;
using PS.UiFramework.Provider;
using Zenject;

namespace PS.UiFramework.Zenject
{
    /// <summary>
    /// Configures and installs bindings for the UI framework components using Zenject.
    /// </summary>
    public class UiFrameworkInstaller : Installer<UiFrameworkInstaller>
    {
        public override void InstallBindings()
        {
            UiFrameworkConfigsInstaller.Install(Container);
            
            InstallInterfaces<PanelsProvider>();
            InstallInterfaces<PanelsController>();
            InstallInterfaces<PanelsInstantiator>();
            InstallInterfaces<PanelsLayersController>();
            InstallInterfacesAndSelf<PanelsContainerProxy>();
            InstallInterfaces<UiFrameworkInitializer>();
        }

        private void InstallInterfaces<TContract>()
        {
            Container
                .BindInterfacesTo<TContract>()
                .AsSingle();
        }

        private void InstallInterfacesAndSelf<TContract>()
        {
            Container
                .BindInterfacesAndSelfTo<TContract>()
                .AsSingle();
        }
    }
}