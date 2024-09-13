using PS.UiFramework.Extensions;
using PS.UiFramework.Unsubscribe;
using PS.UiFramework.Widgets;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PS.UiFramework.Example.Source.Widgets.Resources
{
    //NOTE: a little more complex example of communication between WidgetView and WidgetViewModel
    public class ResourcesWidgetView : AWidgetView<ResourcesWidgetViewModel>
    {
        [Header("Texts")] 
        [SerializeField] private TextMeshProUGUI _coinsText;

        [Header("Buttons")] 
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _resetButton;
        
        protected override void Subscribe(UnsubscribeLink unsubscribeLink)
        {
            _viewModel.Coins.SubscribeWithLink(OnCoins, unsubscribeLink);

            _addButton
                .OnClickAsObservable()
                .SubscribeWithLink(_ => _viewModel.AddCoin(), unsubscribeLink);

            _resetButton
                .OnClickAsObservable()
                .SubscribeWithLink(_ => _viewModel.ResetCoin(), unsubscribeLink);
        }

        private void OnCoins(int coins)
        {
            _coinsText.text = $"Coins: {coins}";
        }
    }
}