using PS.UiFramework.Panels;
using PS.UiFramework.Panels.Components;
using UnityEngine;

namespace PS.UiFramework.Extensions
{
    internal static class PanelExtensions
    {
        internal static TPanelComponent EnsurePanelComponentCreated<TPanelComponent>(this APanel panel, string gameObjectName)
            where TPanelComponent : MonoBehaviour, IPanelComponent
        {
            var panelComponent = panel.GetComponentInChildren<TPanelComponent>();

            if (panelComponent != null)
                return panelComponent;

            var componentObject = new GameObject(gameObjectName);
            componentObject.transform.SetParent(panel.transform);
                
            var componentRectTransform = componentObject.AddComponent<RectTransform>();
            componentRectTransform.Reset();
            componentRectTransform.Stretch();
            
            return componentObject.AddComponent<TPanelComponent>();
        }
    }
}