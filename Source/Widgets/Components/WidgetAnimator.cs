using System.Linq;
using Cysharp.Threading.Tasks;
using PS.UiFramework.Animations;

namespace PS.UiFramework.Widgets.Components
{
    public class WidgetAnimator
    {
        private readonly AWidgetAnimation[] _animations;

        public WidgetAnimator(AWidgetAnimation[] animations)
        {
            _animations = animations;
        }

        public async UniTask AnimateAsync(EAnimationType animationType)
        {
            var animationTasks = _animations
                .Where(a => a.IsEnabled && a.Type == animationType)
                .Select(a => a.animateAsync());

            await UniTask.WhenAll(animationTasks);
        }
    }
}