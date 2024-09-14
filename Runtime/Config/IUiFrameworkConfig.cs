using PS.UiFramework.Container;

namespace PS.UiFramework.Config
{
    /// <summary>
    /// Provides access to UI framework configuration settings.
    /// </summary>
    public interface IUiFrameworkConfig
    {
        /// <summary>
        /// Gets the settings for controlling the layers in the UI framework.
        /// </summary>
        LayersControllerSettings LayersSettings { get; }
        
        /// <summary>
        /// Gets the prefab used for the panels container in the UI framework.
        /// </summary>
        PanelsContainer ContainerPrefab { get; }
    }
}