using System.Linq;
using PS.UiFramework.Animations;
using PS.UiFramework.Editor.Extensions;
using PS.UiFramework.Panels;
using PS.UiFramework.Source.Editor;
using UnityEditor;

namespace PS.UiFramework.Editor.Panel
{
    [CustomEditor(typeof(PanelAnimatorInspector))]
    public class PanelAnimatorInspectorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var panelAnimatorInspector = (PanelAnimatorInspector)target;
            var targetPanel = panelAnimatorInspector.GetComponentInParent<APanel>(includeInactive: true);

            var animations = panelAnimatorInspector.GetComponents<APanelAnimation>();
            
            var openAnimations = animations
                .Where(a => a.Type == EAnimationType.OnOpen).ToList();

            var enabledOpenAnimations = openAnimations
                .Where(a => a.IsEnabled).ToList();
            
            var closeAnimations = animations
                .Where(a => a.Type == EAnimationType.OnClose).ToList();

            var enabledCloseAnimations = closeAnimations
                .Where(a => a.IsEnabled).ToList();

            if (targetPanel == null)
            {
                EditorGUILayout.HelpBox("Panel not found for this animator", MessageType.Error);
                return;
            }
            
            EditorGUILayout.BeginVertical("box");
            
            CustomEditorElements.SeparatorLine();
            
            CustomEditorElements.BigHeader("Panel Animator");

            CustomEditorElements.SeparatorLine();
            
            CustomEditorElements.PanelLink(targetPanel);

            CustomEditorElements.SeparatorLine();

            EditorGUILayout.BeginVertical("box");
            
            EditorGUILayout.LabelField("Open Animations", CustomEditorStyles.HeaderStyle);
            EditorGUILayout.LabelField($"Total - {openAnimations.Count}, Enabled - {enabledOpenAnimations.Count}", CustomEditorStyles.DefaultStyle);
            
            EditorGUILayout.EndVertical();
            
            CustomEditorElements.SeparatorLine();

            EditorGUILayout.BeginVertical("box");
            
            EditorGUILayout.LabelField("Close Animations", CustomEditorStyles.HeaderStyle);
            EditorGUILayout.LabelField($"Total - {closeAnimations.Count}, Enabled - {enabledCloseAnimations.Count}", CustomEditorStyles.DefaultStyle);
            
            EditorGUILayout.EndVertical();

            CustomEditorElements.SeparatorLine();
            EditorGUILayout.EndVertical();
        }
    }
}