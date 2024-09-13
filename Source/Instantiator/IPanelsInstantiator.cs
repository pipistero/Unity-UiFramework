using PS.UiFramework.Panels;

namespace PS.UiFramework.Instantiator
{
    /// <summary>
    /// Provides methods to create, register, destroy, and unregister UI panels.
    /// </summary>
    public interface IPanelsInstantiator
    {
        /// <summary>
        /// Creates and registers a new UI panel of the specified type.
        /// </summary>
        /// <typeparam name="TPanel">The type of panel to create, must inherit from APanel.</typeparam>
        void CreateAndRegisterPanel<TPanel>() where TPanel : APanel;
        
        /// <summary>
        /// Destroys and unregisters the UI panel of the specified type.
        /// </summary>
        /// <typeparam name="TPanel">The type of panel to destroy, must inherit from APanel.</typeparam>
        void DestroyAndUnregisterPanel<TPanel>() where TPanel : APanel;
    }
}