using DAL.Entites;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ServInger.UI.Controls
{
    class ParameterDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SlidTemplate { get; set; }
        public DataTemplate CheckTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if ((item as TestimonyEntity)?.Type == 1)
                return CheckTemplate;
            return SlidTemplate;
        }
    }
}
