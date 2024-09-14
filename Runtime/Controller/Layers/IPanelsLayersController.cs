using PS.UiFramework.Panels;

namespace PS.UiFramework.Controller.Layers
{
    public interface IPanelsLayersController
    {
        public void SetPanelLayer(APanel panel);
        public void PanelClosed(APanel panel);
    }
}