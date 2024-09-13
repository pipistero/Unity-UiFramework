using PS.UiFramework.Panels;

namespace PS.UiFramework.Provider
{
    public interface IPanelsProvider
    {
        bool TryGetPanel<TPanel>(out APanel panel) where TPanel : APanel;

        void RegisterPanel<TPanel>(TPanel panel) where TPanel : APanel;
        void UnregisterPanel<TPanel>() where TPanel : APanel;
    }
}