using System;
using UnityEngine;

namespace PS.UiFramework.Config
{
    /// <summary>
    /// Contains settings related to controlling the sorting order of UI panels.
    /// </summary>
    [Serializable]
    public sealed class LayersControllerSettings
    {
        /// <summary>
        /// Gets the step size for the sorting order between panels.
        /// </summary>
        [field: SerializeField, Min(0)] public int SortingOrderStep { get; private set; } = 10;
        
        /// <summary>
        /// Gets the default sorting order for UI panels.
        /// </summary>
        [field: SerializeField] public int DefaultSortingOrder { get; private set; }
    }
}