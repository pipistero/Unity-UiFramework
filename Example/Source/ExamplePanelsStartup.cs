using PS.UiFramework.Controller;
using PS.UiFramework.Example.Source.Panels;
using UnityEngine;
using Zenject;

namespace PS.UiFramework.Example.Source
{
    public class ExamplePanelsStartup : MonoBehaviour
    {
        [Inject] private IPanelsController _panelsController;

        private void Start()
        {
            _panelsController.OpenExtraordinary<ExtraordinaryExamplePanel>();
        }
    }
}