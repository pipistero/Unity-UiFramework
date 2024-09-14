using System.Collections.Generic;
using PS.UiFramework.Config;
using PS.UiFramework.Panels;

namespace PS.UiFramework.Controller.Layers
{
    public sealed class PanelsLayersController : IPanelsLayersController
    {
        private readonly IUiFrameworkConfig _config;
        private readonly List<APanel> _openedPanels = new();

        public PanelsLayersController(IUiFrameworkConfig config)
        {
            _config = config;
        }

        public void SetPanelLayer(APanel panel)
        {
            panel.SortingOrder = CalculateNextSortingOrder();
            _openedPanels.Add(panel);
            
            return;

            int CalculateNextSortingOrder()
            {
                if (_openedPanels.Count == 0) 
                    return _config.LayersSettings.DefaultSortingOrder;

                return _openedPanels[^1].SortingOrder + _config.LayersSettings.SortingOrderStep;
            }
        }

        public void PanelClosed(APanel panel)
        {
            if (_openedPanels.Contains(panel) == false)
                return;
            
            _openedPanels.Remove(panel);
            RecalculateSortingOrders();
            
            return;
            
            void RecalculateSortingOrders()
            {
                var currentSortingOrder = _config.LayersSettings.DefaultSortingOrder;
            
                foreach (var openedPanel in _openedPanels)
                {
                    openedPanel.SortingOrder = currentSortingOrder;
                    currentSortingOrder += _config.LayersSettings.SortingOrderStep;
                }
            }
        }
    }
}