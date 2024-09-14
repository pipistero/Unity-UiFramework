namespace PS.UiFramework.Panels
{
    /// <summary>
    /// Provides a method to initialize a panel, typically called after the panel's components are set up.
    /// </summary>
    public interface IPanelInitializable
    {
        /// <summary>
        /// Called to initialize the panel. This method should contain logic that sets up the panel after its components have been created.
        /// </summary>
        void OnInitialize();
    }
}