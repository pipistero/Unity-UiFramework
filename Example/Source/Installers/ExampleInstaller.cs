using PS.UiFramework.Zenject;
using Zenject;

namespace PS.UiFramework.Example.Source.Installers
{
    //NOTE: you can use prefab or simply call UiFrameworkInstaller.Install in ProjectContext
    //NOTE: you can find prefab of this installer in Prefabs folder in UiFramework main directory
    public class ExampleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            UiFrameworkInstaller.Install(Container);
        }
    }
}

