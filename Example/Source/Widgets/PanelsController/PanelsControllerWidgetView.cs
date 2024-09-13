using PS.UiFramework.Example.Source.Panels;
using PS.UiFramework.Extensions;
using PS.UiFramework.Unsubscribe;
using PS.UiFramework.Widgets;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace PS.UiFramework.Example.Source.Widgets.PanelsController
{
    //NOTE: simple example of communication WidgetViewModel and WidgetView
    public class PanelsControllerWidgetView : AWidgetView<PanelsControllerWidgetViewModel>
    {
        [Header("Buttons")] 
        [SerializeField] private Button _toggleResourcesPanelButton;
        [SerializeField] private Button _toggleAnimatedPanelButton;
        
        //NOTE: subscribe to any of Observable in your WidgetViewModel
        protected override void Subscribe(UnsubscribeLink unsubscribeLink)
        {
            _toggleResourcesPanelButton
                .OnClickAsObservable()
                .SubscribeWithLink(_ => _viewModel.TogglePanel<ResourcesExamplePanel>(), unsubscribeLink);
            
            _toggleAnimatedPanelButton
                .OnClickAsObservable()
                .SubscribeWithLink(_ => _viewModel.TogglePanel<AnimatedExamplePanel>(), unsubscribeLink);
        }
    }
}