using System;
using SmartNewsDemo.Common.Control;
using SmartNewsDemo.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SmartNewsDemo.iOS.CustomRenderer
{
    public class CustomEntryRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

                UITextField textField = Control;
                textField.BorderStyle = UITextBorderStyle.None;
                textField.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            }
        }
    }
}
