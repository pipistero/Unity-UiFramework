using UnityEngine;

namespace PS.UiFramework.Container
{
    public class PanelsContainer : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(gameObject);
    }
}