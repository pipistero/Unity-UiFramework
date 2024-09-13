using PS.UiFramework.Source.Editor;
using UnityEngine;
using UnityEngine.UI;

namespace PS.UiFramework.Panels.Components
{
#if UNITY_EDITOR
    [RequireComponent(typeof(PanelRootInspector))]
#endif
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup), typeof(GraphicRaycaster))]
    public class PanelRoot : MonoBehaviour, IPanelComponent
    {
        private RectTransform _rectTransform;
        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                    _rectTransform = GetComponent<RectTransform>();

                return _rectTransform;
            }
        }

        private CanvasGroup _canvasGroup;
        public CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup == null)
                    _canvasGroup = GetComponent<CanvasGroup>();

                return _canvasGroup;
            }
        }
        
        private Canvas _canvas;
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                    _canvas = GetComponent<Canvas>();

                return _canvas;
            }
        }
    }
}