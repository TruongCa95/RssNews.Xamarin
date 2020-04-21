using System;
using Xamarin.Forms;

namespace SmartNewsDemo.Common.Control
{
    public class WebViewControl: WebView
    {
        public static BindableProperty RefreshCommandProperty = BindableProperty.Create
            (nameof(RefreshCommand),
            typeof(Action),
            typeof(WebViewControl),
            null,
            BindingMode.OneWayToSource);
        public Action RefreshCommand
        {
            get => (Action)GetValue(RefreshCommandProperty);
            set
            {
                SetValue(RefreshCommandProperty, value);
            }
        }
        public static BindableProperty GobackCommandProperty = BindableProperty.Create
            (nameof(GobackCommand),
            typeof(Action),
            typeof(WebViewControl),
            null,
            BindingMode.OneWayToSource);
        public Action GobackCommand
        {
            get => (Action)GetValue(GobackCommandProperty);
            set
            {
                SetValue(RefreshCommandProperty, value);
            }
        }
        public static BindableProperty CanGobackfunctionProperty = BindableProperty.Create
            (nameof(CanGoBackFunction),
            typeof(Func<bool>),
            typeof(WebViewControl),
            null,
            BindingMode.OneWayToSource
            );

        public Func<bool> CanGoBackFunction
        {
            get=> (Func<bool>)GetValue(CanGobackfunctionProperty);
            set
            {
                SetValue(CanGobackfunctionProperty, value);
            }
        }

        public static BindableProperty GoforwardCommandProperty = BindableProperty.Create
            (nameof(GoforwardCommand),
            typeof(Action),
            typeof(WebViewControl),
            null,
            BindingMode.OneWayToSource);

        public Action GoforwardCommand
        {
            get => (Action)GetValue(GobackCommandProperty);
            set
            {
                SetValue(GobackCommandProperty, value);
            }
        }
        public static BindableProperty CanGoforwardProperty = BindableProperty.Create
            (nameof(CanGoForwardfunction),
            typeof(Func<bool>),
            typeof(WebViewControl),
            null,
            BindingMode.OneWayToSource);
        public Func<bool> CanGoForwardfunction
        {
            get => (Func<bool>)GetValue(CanGoForwardProperty);
            set
            {
                SetValue(CanGoForwardProperty, value);
            }
        }
    }
}
