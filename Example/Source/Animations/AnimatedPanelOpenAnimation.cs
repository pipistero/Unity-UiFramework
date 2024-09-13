using Cysharp.Threading.Tasks;
using DG.Tweening;
using PS.UiFramework.Animations;
using UnityEngine;

namespace PS.UiFramework.Example.Source.Animations
{
    //NOTE: place component on PanelAnimator of your panel to work
    public class AnimatedPanelOpenAnimation : APanelAnimation
    {
        //NOTE: highly recommend to get settings from ScriptableObject
        [Header("Settings")] 
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        
        //NOTE: always await your animation end
        //NOTE: do not use other targets than the CanvasGroup and RectTransform passed in the parameters of method 
        protected override async UniTask AnimateAsync(CanvasGroup canvasGroup, RectTransform root)
        {
            await canvasGroup.DOFade(1f, _duration).SetEase(_ease);
        }
    }
}