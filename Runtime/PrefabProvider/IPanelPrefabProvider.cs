using PS.UiFramework.Panels;

namespace PS.UiFramework.PrefabProvider
{
    public interface IPanelPrefabProvider
    {
        bool TryGet<TPanel>(out TPanel panel) where TPanel : APanel;
    }
}