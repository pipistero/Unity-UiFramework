using PS.UiFramework.Panels;
using UnityEditor;
using UnityEngine;

namespace PS.UiFramework.Editor.Extensions
{
    public static class CustomEditorElements
    {
        public static void SeparatorLine()
        {
            EditorGUILayout.LabelField(string.Empty, GUI.skin.horizontalSlider);
        }

        public static void BigHeader(string text)
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField(text, CustomEditorStyles.BigHeaderStyle);
            EditorGUILayout.EndVertical();
        }
        
        public static void PanelLink(APanel targetPanel)
        {
            EditorGUILayout.BeginVertical("box");
            
            BeginHorizontalWithFlexibleSpace();
            
            EditorGUILayout.LabelField($"Panel: <i>{targetPanel.GetType().Name}</i>", CustomEditorStyles.HeaderStyle);

            if (GUILayout.Button("Select panel"))
                EditorExtensions.SelectObject(targetPanel.gameObject);

            EndHorizontalWithFlexibleSpace();
            
            EditorGUILayout.EndHorizontal();
        }

        public static void BeginHorizontalWithFlexibleSpace()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
        }

        public static void EndHorizontalWithFlexibleSpace()
        {
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }
    }
}