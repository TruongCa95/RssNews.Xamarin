using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SmartNewsDemo.Droid
{
    //const string CALLBACK_SCHEME = "myapp";

    //[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    //[IntentFilter(new[] { Intent.ActionView },
    //    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    //    DataScheme = CALLBACK_SCHEME)]
    public class WebAuthenticationCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
    }
}