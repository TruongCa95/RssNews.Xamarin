using System;
using SmartNewsDemo.Common.Control;
using SmartNewsDemo.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace SmartNewsDemo.iOS.CustomRenderer
{
    public class CustomButtonRenderer: ButtonRenderer
    {
        public CustomButtonRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
                Control.TitleLabel.Lines = 0;
                Control.TitleLabel.TextAlignment = UITextAlignment.Center;
            }
        }
    }
}
