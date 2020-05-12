using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SmartNewsDemo.ViewModel;
using Xamarin.Forms;

namespace SmartNewsDemo.Common.Control
{
    public partial class CardView : ContentView
    {
        public string NotificationNumber;
        public static readonly BindableProperty TitleProperty = BindableProperty.Create
           (
           nameof(Title),
           typeof(string),
           typeof(CardView),
           string.Empty,
           BindingMode.TwoWay,
           propertyChanged: TitleTextPropertyChanged
           );
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set { SetValue(TitleProperty, value); }
        }
        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CardView)bindable;
            control.lblTitle.Text = newValue.ToString();
        }


        public static readonly BindableProperty NotificationProperty = BindableProperty.Create
            (
            nameof(Notification),
            typeof(string),
            typeof(CardView),
            "",
            BindingMode.TwoWay
            );
        public string Notification
        {
            get => (string)GetValue(NotificationProperty);
            set { SetValue(NotificationProperty, value); }
        }
 

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            HomeSettingViewModel.NotificationEvent += NotificationHandle;
            if (propertyName == NotificationProperty.PropertyName)
            {
                lblNotifi.Text = NotificationNumber;
            }
        }

        private void NotificationHandle(object sender, int e)
        {
            NotificationNumber = e < 99 ? NotificationNumber = e.ToString() : "99+";
        }

        public static readonly BindableProperty IconProperty = BindableProperty.Create
            (
            nameof(Icon),
            typeof(string),
            typeof(CardView),
            null, BindingMode.TwoWay,
            propertyChanged: IconSourcePropertyChanged
            );
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set { SetValue(IconProperty, value); }
        }
        private static void IconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CardView)bindable;
            control.ImgIcon.Source = ImageSource.FromFile(newValue.ToString());
        }
        public CardView()
        {
            InitializeComponent();
        }
    }
}
