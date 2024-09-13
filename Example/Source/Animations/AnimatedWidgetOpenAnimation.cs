using Cysharp.Threading.Tasks;
using DG.Tweening;
using PS.UiFramework.Animations;
using UnityEngine;

namespace PS.UiFramework.Example.Source.Animations
{
    //NOTE: place component on your widget to work
    public class AnimatedWidgetOpenAnimation : AWidgetAnimation
    {
        //NOTE: you can set any animation targets inside widget 
        [Header("Targets")] 
        [SerializeField] private Transform _shakeTarget;
        [SerializeField] private Transform _rotationTarget;

        //NOTE: highly recommend to get settings from ScriptableObject
        [Header("Shake settings")] 
        [SerializeField] private float _shakeDuration;

        [Header("Rotation settings")] 
        [SerializeField] private float _rotationDuration;
        [SerializeField] private Ease _rotationEase;
        
        //NOTE: always await your animation end
        protected override async UniTask AnimateAsync()
        {
            var sequence = DOTween.Sequence();

            sequence.Append(_shakeTarget.DOShakeScale(_shakeDuration));
            sequence.Append(_rotationTarget.DORotate(Vector3.forward * 360f, _rotationDuration, RotateMode.FastBeyond360).SetEase(_rotationEase));

            await sequence.Play();
        }
    }
}