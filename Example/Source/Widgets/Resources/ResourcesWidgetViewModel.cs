using PS.UiFramework.Widgets;
using R3;

namespace PS.UiFramework.Example.Source.Widgets.Resources
{
    //NOTE: a little more complex example of communication between WidgetView and WidgetViewModel
    public class ResourcesWidgetViewModel : IWidgetViewModel, IWidgetViewModelInitializable
    {
        public Observable<int> Coins => _coins;
        private readonly ReactiveProperty<int> _coins = new();

        //NOTE: this method provided by IWidgetViewModelInitializable interface
        //NOTE: you can use this method for one-time setup
        public void Initialize()
        {
            _coins.Value = 100;
        }

        //NOTE: this method used by WidgetView
        public void AddCoin()
        {
            _coins.Value += 1;
        }

        //NOTE: this method also used by WidgetView
        public void ResetCoin()
        {
            _coins.Value = 0;
        }
    }
}