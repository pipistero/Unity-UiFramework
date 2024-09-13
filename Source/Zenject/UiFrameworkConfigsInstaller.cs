using PS.UiFramework.Config;
using PS.UiFramework.PrefabProvider;
using PS.UiFramework.StaticData;
using Zenject;

namespace PS.UiFramework.Zenject
{
    /// <summary>
    /// Configures and installs bindings for UI framework configuration using Zenject.
    /// </summary>
    public class UiFrameworkConfigsInstaller : Installer<UiFrameworkConfigsInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUiFrameworkConfig>()
                .To<UiFrameworkConfig>()
                .FromScriptableObjectResource(ResourcesPathProvider.UI_FRAMEWORK_CONFIG_PATH)
                .AsSingle();
            
            //TODO: add if like PANELS_CONTAINER_SO
            Container
                .Bind<IPanelPrefabProvider>()
                .To<ScriptableObjectPanelPrefabProvider>()
                .FromScriptableObjectResource(ResourcesPathProvider.PANELS_PREFABS_CONFIG_PATH)
                .AsSingle();
        }
    }
}