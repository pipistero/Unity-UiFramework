using System.Reflection;
using PS.UiFramework.Widgets;
using Zenject;

namespace PS.UiFramework.Attributes
{
    internal static class WidgetViewInjector
    {
        internal static IWidgetViewModel InjectViewModel(this IWidgetView widgetView, IInstantiator instantiator)
        {
            var widgetViewType = widgetView.GetType();
            var viewFieldsInfo = widgetViewType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            foreach (var fieldInfo in viewFieldsInfo)
            {
                var injectAttribute = fieldInfo.GetCustomAttribute<InjectViewModelAttribute>();
                if (injectAttribute == null) 
                    continue;
                
                var viewModelType = fieldInfo.FieldType;
                var viewModelInstance = instantiator.Instantiate(viewModelType);

                fieldInfo.SetValue(widgetView, viewModelInstance);

                return (IWidgetViewModel)viewModelInstance;
            }

            return default;
        }
    }
}