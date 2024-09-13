using UnityEditor;
using UnityEngine;

namespace PS.UiFramework.Editor.Extensions
{
    public static class CustomEditorStyles
    {
        #region Headers styles

        public static readonly GUIStyle BigHeaderStyle = new(EditorStyles.label)
        {
            richText = true,
            fontSize = 16,
            alignment = TextAnchor.MiddleCenter
        };

        public static readonly GUIStyle HeaderStyle = new(EditorStyles.label)
        {
            richText = true,
            fontSize = 14,
            alignment = TextAnchor.MiddleCenter
        };

        #endregion
        
        public static readonly GUIStyle DefaultStyle = new(EditorStyles.label)
        {
            richText = true,
            fontSize = 12,
            alignment = TextAnchor.MiddleCenter
        };

        public static readonly GUIStyle PanelOpenStateStyle = new(EditorStyles.label)
        {
            richText = true,
            fontSize = 14,
            normal = { textColor = Color.green },
            alignment = TextAnchor.MiddleCenter
        };

        public static readonly GUIStyle PanelCloseStateStyle = new(EditorStyles.label)
        {
            richText = true,
            fontSize = 14,
            normal = { textColor = Color.red },
            alignment = TextAnchor.MiddleCenter
        };
        
        public static readonly GUIStyle WidgetNameStyle = new(EditorStyles.miniLabel)
        {
            richText = true,
            fontSize = 12,
        };
    }
}