using PS.UiFramework.Container;
using PS.UiFramework.StaticData;
using UnityEditor;
using UnityEngine;

namespace PS.UiFramework.Config
{
    /// <inheritdoc cref="IUiFrameworkConfig"/>
    [CreateAssetMenu(menuName = ContextMenuNames.CONFIGS_PATH + nameof(UiFrameworkConfig))]
    public sealed class UiFrameworkConfig : ScriptableObject, IUiFrameworkConfig
    {
        /// <inheritdoc />
        [field: SerializeField] public LayersControllerSettings LayersSettings { get; private set; }
        
        /// <inheritdoc />
        [field: SerializeField] public PanelsContainer ContainerPrefab { get; private set; }
        
        [field: SerializeField] public GameObject EmptyPanelPrefab { get; private set; }
        [field: SerializeField] public SceneAsset DevScene { get; private set; }
    }
}