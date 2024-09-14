using Cysharp.Threading.Tasks;
using PS.UiFramework.Animations;
using PS.UiFramework.Widgets;

namespace PS.UiFramework.Panels.Components
{
    public class PanelWidgets
    {
        private readonly IWidgetView[] _views;

        public PanelWidgets(APanel panel)
        {
            _views = panel.GetComponentsInChildren<IWidgetView>();
        }

        public void Initialize()
        {
            InitializeWidgets();
            SubscribeWidgets();
        }

        public async UniTask AnimateAsync(EAnimationType animationType)
        {
            var animationTasks = _views.Select(v => v.AnimateAsync(animationType));
            await UniTask.WhenAll(animationTasks);
        }

        private void InitializeWidgets()
        {
            foreach (var view in _views)
            {
                view.Initialize();
            }
        }

        private void SubscribeWidgets()
        {
            foreach (var view in _views)
            {
                view.Subscribe();
            }
        }
    }
}