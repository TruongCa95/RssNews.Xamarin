using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace SmartNewsDemo.Common.Control
{
    public partial class TabItem : StackLayout
    {
        public event EventHandler<string> OnTabItemClicked;

        public static readonly BindableProperty UrlProperty = BindableProperty.Create
           (
           nameof(Url),
           typeof(string),
           typeof(TabItem),
           string.Empty);
        public string Url
        {
            get => (string)GetValue(UrlProperty);
            set { SetValue(UrlProperty, value); }
        }

        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create
            (nameof(ItemSource),
            typeof(IEnumerable),
            typeof(TabItem), null,
            BindingMode.Default,
            null);
        public IEnumerable ItemSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set { SetValue(ItemSourceProperty, value); }
        }


        public TabItem()
        {
            InitializeComponent();
        }

        private void OnContentTapped(object sender, EventArgs e)
        {
            var pancake = (PancakeView)sender;
            var title = pancake.FindByName<Label>("lblTitle").Text;
            EventHandler<string> handler = OnTabItemClicked;
            handler?.Invoke(sender, title);
        }
    }
}
