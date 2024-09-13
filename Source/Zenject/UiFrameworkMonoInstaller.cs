using Zenject;

namespace PS.UiFramework.Zenject
{
    public class UiFrameworkMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            UiFrameworkInstaller.Install(Container);
        }
    }
}