using Android.Content;
using Android.Graphics.Drawables;
using SmartNewsDemo.Common.Control;
using SmartNewsDemo.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace SmartNewsDemo.Droid.CustomRenderer
{
  public class CustomButtonRenderer: ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new ColorDrawable(Color.Transparent.ToAndroid());
            }
        }
    }
}