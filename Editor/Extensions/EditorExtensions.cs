using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PS.UiFramework.Editor.Extensions
{
    public static class EditorExtensions
    {
        public static bool HasSerializedFields(Object targetObject)
        {
            var o = new SerializedObject(targetObject);
            var property = o.GetIterator();

            while (property.NextVisible(true))
            {
                if (property.propertyType != SerializedPropertyType.ObjectReference || property.objectReferenceValue != null) 
                    continue;

                return true;
            }

            return false;
        }

        public static SerializedProperty SerializedFields(Object targetObject)
        {
            var o = new SerializedObject(targetObject);
            var property = o.GetIterator();

            return property;
        }

        public static void SelectObject(GameObject gameObject)
        {
            Selection.activeGameObject = gameObject;
            EditorGUIUtility.PingObject(gameObject);
            EditorApplication.RepaintHierarchyWindow();
        }
    }
}