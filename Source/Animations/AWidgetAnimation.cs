using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PS.UiFramework.Animations
{
    public abstract class AWidgetAnimation : MonoBehaviour
    {
        [field: Header("Settings")]
        [field: SerializeField] public EAnimationType Type { get; private set; }
        [field: SerializeField] public bool IsEnabled { get; private set; } = true;
        [field: SerializeField] public float Delay { get; private set; }
        
        internal async UniTask animateAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(Delay));
            await AnimateAsync();
        }
        
        protected abstract UniTask AnimateAsync();
    }
}