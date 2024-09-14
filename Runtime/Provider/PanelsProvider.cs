using System;
using System.Collections.Generic;
using PS.UiFramework.Panels;

namespace PS.UiFramework.Provider
{
    public sealed class PanelsProvider : IPanelsProvider
    {
        private readonly Dictionary<Type, APanel> _panels = new();

        public bool TryGetPanel<TPanel>(out APanel panel) where TPanel : APanel
        {
            return _panels.TryGetValue(typeof(TPanel), out panel);
        }

        public void RegisterPanel<TPanel>(TPanel panel) where TPanel : APanel
        {
            _panels.Add(typeof(TPanel), panel);
        }

        public void UnregisterPanel<TPanel>() where TPanel : APanel
        {
            _panels.Remove(typeof(TPanel), out var panel);
        }
    }
}