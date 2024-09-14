using UnityEngine;

namespace PS.UiFramework.Source.Editor
{
    public class EditorMonoBehaviour : MonoBehaviour
    {
#if !UNITY_EDITOR
        private void Awake() => Destroy(this);
#endif
    }
}