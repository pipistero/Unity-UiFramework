using PS.UiFramework.Editor.Extensions;
using PS.UiFramework.Panels;
using PS.UiFramework.Panels.Components;
using PS.UiFramework.Source.Editor;
using PS.UiFramework.Widgets;
using UnityEditor;
using UnityEngine;

namespace PS.UiFramework.Editor.Panel
{
    [CustomEditor(typeof(PanelInspector), true)]
    public class PanelInspectorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var targetPanelInspector = (PanelInspector)target;
            var targetPanel = targetPanelInspector.GetComponent<APanel>();
            var widgetViews = targetPanelInspector.GetComponentsInChildren<IWidgetView>();
            var panelRoot = targetPanelInspector.GetComponentInChildren<PanelRoot>();
            var panelAnimator = targetPanelInspector.GetComponentInChildren<PanelAnimator>();

            if (targetPanel == null)
            {
                EditorGUILayout.HelpBox("Panel not found on this game object", MessageType.Error);
                return;
            }
            
            EditorGUILayout.BeginVertical("box");
            
            CustomEditorElements.SeparatorLine();
            
            EditorGUILayout.BeginVertical("box");

            var panelStateStyle = targetPanel.State is EPanelState.Open or EPanelState.InOpenAnimation
                ? CustomEditorStyles.PanelOpenStateStyle
                : CustomEditorStyles.PanelCloseStateStyle;
            
            EditorGUILayout.LabelField($"{targetPanel.GetType().Name}", CustomEditorStyles.BigHeaderStyle);
            EditorGUILayout.LabelField($"{targetPanel.State}", panelStateStyle);

            EditorGUILayout.EndVertical();
            
            CustomEditorElements.SeparatorLine();
            
            EditorGUILayout.LabelField("Panel Widgets", CustomEditorStyles.HeaderStyle);
            EditorGUILayout.Space();

            foreach (var widgetView in widgetViews)
            {
                EditorGUILayout.BeginVertical("box");

                CustomEditorElements.BeginHorizontalWithFlexibleSpace();
                
                EditorGUILayout.LabelField($"Widget: <i>{widgetView.GetType().Name}</i>", CustomEditorStyles.WidgetNameStyle);

                if (GUILayout.Button("Select widget"))
                    EditorExtensions.SelectObject(((Component)widgetView).gameObject);
                
                CustomEditorElements.EndHorizontalWithFlexibleSpace();
                
                if (EditorExtensions.HasSerializedFields((Component)widgetView))
                    EditorGUILayout.HelpBox("This widget has unassigned serialized fields.", MessageType.Warning);
                
                EditorGUILayout.EndVertical();
            }
            
            if (widgetViews.Length == 0) 
                EditorGUILayout.HelpBox("There are no widgets on this panel", MessageType.Error);
            
            CustomEditorElements.SeparatorLine();
            
            EditorGUILayout.LabelField("Panel Components", CustomEditorStyles.HeaderStyle);
            EditorGUILayout.Space();
            
            EditorGUILayout.BeginVertical("box");
            
            CustomEditorElements.BeginHorizontalWithFlexibleSpace();
            
            EditorGUILayout.LabelField("<i>Panel Root</i>", CustomEditorStyles.WidgetNameStyle);

            if (GUILayout.Button("Select root"))
                EditorExtensions.SelectObject(panelRoot.gameObject);
            
            CustomEditorElements.EndHorizontalWithFlexibleSpace();
            
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.BeginVertical("box");
            
            CustomEditorElements.BeginHorizontalWithFlexibleSpace();
            
            EditorGUILayout.LabelField("<i>Panel Animator</i>", CustomEditorStyles.WidgetNameStyle);

            if (GUILayout.Button("Select animator"))
                EditorExtensions.SelectObject(panelAnimator.gameObject);
            
            CustomEditorElements.EndHorizontalWithFlexibleSpace();
            
            EditorGUILayout.EndVertical();
            
            CustomEditorElements.SeparatorLine();
            EditorGUILayout.EndVertical();
        }
    }
}
