using Cysharp.Threading.Tasks;
using PS.UiFramework.Panels;

namespace PS.UiFramework.Controller
{
    /// <summary>
    /// The PanelsController class is responsible for managing the opening, closing, and toggling of UI panels.
    /// </summary>
    public interface IPanelsController
    {
        /// <summary>
        /// Opens the specified panel if it is not already open or in the process of opening.
        /// </summary>
        /// <typeparam name="TPanel">The type of the panel to be opened, which must inherit from <see cref="APanel"/>.</typeparam>
        /// <returns>A UniTask representing the asynchronous operation of opening the panel.</returns>
        UniTask Open<TPanel>() where TPanel : APanel;
        
        /// <summary>
        /// Opens the specified panel with an extraordinary sorting order, allowing it to appear above other panels.
        /// </summary>
        /// <typeparam name="TPanel">The type of the panel to be opened, which must inherit from <see cref="APanel"/>.</typeparam>
        /// <param name="sortingOrder">The sorting order for the panel. Defaults to the maximum value.</param>
        /// <returns>A UniTask representing the asynchronous operation of opening the panel.</returns>
        UniTask OpenExtraordinary<TPanel>(int sortingOrder = 32767) where TPanel : APanel;

        /// <summary>
        /// Toggles the state of the specified panel. If the panel is open, it will be closed. 
        /// If it is closed, it will be opened.
        /// </summary>
        /// <typeparam name="TPanel">The type of the panel to be toggled, which must inherit from <see cref="APanel"/>.</typeparam>
        /// <returns>A UniTask representing the asynchronous operation of toggling the panel.</returns>
        UniTask Toggle<TPanel>() where TPanel : APanel;
        
        /// <summary>
        /// Closes the specified panel if it is not already closed or in the process of closing.
        /// </summary>
        /// <typeparam name="TPanel">The type of the panel to be closed, which must inherit from <see cref="APanel"/>.</typeparam>
        /// <returns>A UniTask representing the asynchronous operation of closing the panel.</returns>
        UniTask Close<TPanel>() where TPanel : APanel;
    }
}