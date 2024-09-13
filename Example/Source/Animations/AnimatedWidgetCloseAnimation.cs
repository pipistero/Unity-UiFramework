using Cysharp.Threading.Tasks;
using PS.UiFramework.Animations;

namespace PS.UiFramework.Example.Source.Animations
{
    //NOTE: place component on your widget to work
    public class AnimatedWidgetCloseAnimation : AWidgetAnimation
    {
        //NOTE: always await your animation end
        protected override UniTask AnimateAsync()
        {
            //NOTE: do your async animation logic here
            return UniTask.CompletedTask;
        }
    }
}