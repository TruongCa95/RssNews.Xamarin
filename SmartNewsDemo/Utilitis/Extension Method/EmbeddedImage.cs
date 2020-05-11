using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartNewsDemo.Utilitis
{
    //Because there is no built-in type converter from string to ResourceImageSource, 
    //these types of images cannot be natively loaded by XAML. 
    //Instead, a simple custom XAML markup extension can be written to load images using a Resource ID specified in XAML:
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(ResourceId))
                return null;
            return ImageSource.FromResource(ResourceId);
        }
    }
}
