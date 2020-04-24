using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartNewsDemo.Utilitis
{
    [ContentProperty(nameof(FontAttributes))]
    public class MarkUpExtension : IMarkupExtension
    {
        public FontAttributes FontAttributes { get; set; }
        public Type TargetType { get; set; } = typeof(Label);
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }
    }
}
