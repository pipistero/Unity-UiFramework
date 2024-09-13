using PS.UiFramework.Controller;
using PS.UiFramework.Panels;
using PS.UiFramework.Widgets;
using Zenject;

namespace PS.UiFramework.Example.Source.Widgets.PanelsController
{
    //NOTE: simple example of communication WidgetViewModel and WidgetView
    public class PanelsControllerWidgetViewModel : IWidgetViewModel
    {
        [Inject] private IPanelsController _panelsController;
        
        public void TogglePanel<TPanel>() where TPanel : APanel
        {
            _panelsController.Toggle<TPanel>();
        }
    }
}