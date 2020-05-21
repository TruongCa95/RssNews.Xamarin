using System;
using CoreGraphics;
using SmartNewsDemo.Common.Control;
using SmartNewsDemo.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace SmartNewsDemo.iOS.CustomRenderer
{
    public class CustomFrameRenderer: FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            this.Layer.CornerRadius = 18;
            this.Layer.Bounds.Inset(1, 1);
            Layer.BorderColor = UIColor.White.CGColor;
            Layer.BorderWidth = 2;
            Layer.BackgroundColor = Color.Transparent.ToCGColor();
        }
    }
}
