using PS.UiFramework.Editor.Extensions;
using PS.UiFramework.Panels;
using PS.UiFramework.Source.Editor;
using UnityEditor;

namespace PS.UiFramework.Editor.Panel
{
    [CustomEditor(typeof(PanelRootInspector))]
    public class PanelRootInspectorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var panelAnimatorInspector = (PanelRootInspector)target;
            var targetPanel = panelAnimatorInspector.GetComponentInParent<APanel>(includeInactive: true);

            if (targetPanel == null)
            {
                EditorGUILayout.HelpBox("Panel not found for this animator", MessageType.Error);
                return;
            }
            
            EditorGUILayout.BeginVertical("box");
            
            CustomEditorElements.SeparatorLine();
            
            CustomEditorElements.BigHeader("Panel Root");

            CustomEditorElements.SeparatorLine();
            
            CustomEditorElements.PanelLink(targetPanel);

            CustomEditorElements.SeparatorLine();

            EditorGUILayout.EndVertical();
        }
    }
}