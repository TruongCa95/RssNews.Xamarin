using System;
using Android.Content;
using SmartNewsDemo.Common.Control;
using SmartNewsDemo.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace SmartNewsDemo.Droid.CustomRenderer
{
    public class CustomFrameRenderer: FrameRenderer
    {
        public CustomFrameRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
#pragma warning disable CS0618
            this.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.blue_resct));
#pragma warning restore CS0618
        }
    }
}
