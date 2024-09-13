using PS.UiFramework.Example.Source.Panels;
using PS.UiFramework.Initializer;
using PS.UiFramework.Instantiator;
using UnityEngine;
using Zenject;

namespace PS.UiFramework.Example.Source
{
    public class ExamplePanelsInitializer : MonoBehaviour
    {
        [Inject] private IUiFrameworkInitializer _frameworkInitializer;
        [Inject] private IPanelsInstantiator _panelsInstantiator;

        private void Awake()
        {
            //NOTE: you need to call this method before any interaction with UiFramework (except installing by zenject of course)
            _frameworkInitializer.Initialize();
            
            //NOTE: this is how you create and register panels
            //NOTE: highly recommended to call this in loading
            _panelsInstantiator.CreateAndRegisterPanel<ExtraordinaryExamplePanel>();
            _panelsInstantiator.CreateAndRegisterPanel<ResourcesExamplePanel>();
            _panelsInstantiator.CreateAndRegisterPanel<AnimatedExamplePanel>();
        }

        private void OnDestroy()
        {
            //NOTE: this is how you destroy and unregister panels; you can call it when you don't need a panel
            /*_panelsInstantiator.DestroyAndUnRegisterPanel<ExtraordinaryExamplePanel>();
            _panelsInstantiator.DestroyAndUnRegisterPanel<ResourcesExamplePanel>();
            _panelsInstantiator.DestroyAndUnRegisterPanel<AnimatedExamplePanel>();*/
        }
    }
}