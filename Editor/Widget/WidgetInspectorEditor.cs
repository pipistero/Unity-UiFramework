using PS.UiFramework.Editor.Extensions;
using PS.UiFramework.Panels;
using PS.UiFramework.Source.Editor;
using PS.UiFramework.Widgets;
using UnityEditor;
using UnityEngine;

namespace PS.UiFramework.Editor.Widget
{
    [CustomEditor(typeof(WidgetInspector), true)]
    public class WidgetInspectorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var targetWidgetInspector = (WidgetInspector)target;
            var targetWidget = targetWidgetInspector.gameObject.GetComponent<IWidgetView>();
            var targetPanel = targetWidgetInspector.GetComponentInParent<APanel>(includeInactive: true);
            
            if (targetPanel == null)
            {
                EditorGUILayout.HelpBox("Panel for this widget not found", MessageType.Error);
                return;
            }
            
            EditorGUILayout.BeginVertical("box");
            
            CustomEditorElements.SeparatorLine();
            
            CustomEditorElements.BigHeader($"{targetWidget.GetType().Name}");
            
            CustomEditorElements.SeparatorLine();
            
            CustomEditorElements.PanelLink(targetPanel);

            CustomEditorElements.SeparatorLine();

            if (EditorExtensions.HasSerializedFields((Component)targetWidget))
            {
                var property = EditorExtensions.SerializedFields((Component)targetWidget);

                while (property.NextVisible(true))
                {
                    if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
                        EditorGUILayout.HelpBox($"SerializeField \"{property.name}\" is not assigned", MessageType.Warning);
                }
                
                CustomEditorElements.SeparatorLine();
            }
            
            EditorGUILayout.EndVertical();
        }
    }
}