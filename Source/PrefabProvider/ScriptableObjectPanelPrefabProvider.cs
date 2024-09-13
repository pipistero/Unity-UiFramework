using System.Collections.Generic;
using System.Linq;
using PS.UiFramework.Panels;
using PS.UiFramework.StaticData;
using UnityEngine;

namespace PS.UiFramework.PrefabProvider
{
    [CreateAssetMenu(menuName = ContextMenuNames.PREFAB_PROVIDERS_PATH + nameof(ScriptableObjectPanelPrefabProvider))]
    public class ScriptableObjectPanelPrefabProvider : ScriptableObject, IPanelPrefabProvider
    {
        [Header("All Panels Prefabs")]
        [Tooltip("Any order")]
        [SerializeField] private List<APanel> _panels;

        public bool TryGet<TPanel>(out TPanel panelPrefab) where TPanel : APanel
        {
            var panel = _panels.FirstOrDefault(p => p.GetType() == typeof(TPanel));
            panelPrefab = panel as TPanel;
            
            return panel != default;
        }
    }
}