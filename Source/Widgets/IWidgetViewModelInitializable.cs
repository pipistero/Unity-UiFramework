namespace PS.UiFramework.Widgets
{
    /// <summary>
    /// Defines a contract for view models that require initialization.
    /// </summary>
    public interface IWidgetViewModelInitializable
    {
        /// <summary>
        /// Initializes the view model, setting up necessary data and state.
        /// </summary>
        void Initialize();
    }
}