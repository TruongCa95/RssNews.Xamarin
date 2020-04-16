using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SmartNewsDemo.Common.Control
{
    public partial class TabItem : Label
    {
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
            BindingContext = new SmartNewsDemo.ViewModel.TabViewViewModel();

        }
    }
}
