using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SmartNewsDemo.Common.Control
{
    public partial class CardView : ContentView
    {
        public event EventHandler OnSelected;

        public CardView()
        {
            InitializeComponent();
        }

        #region properties custom

        public static readonly BindableProperty TitleProperty = BindableProperty.Create
           (
           nameof(Title),
           typeof(string),
           typeof(CardView),
           string.Empty,
           BindingMode.TwoWay
           );
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty NotificationProperty = BindableProperty.Create
            (
            nameof(Notification),
            typeof(string),
            typeof(CardView),
            "0",
            BindingMode.TwoWay
            );
        public string Notification
        {
            get => (string)GetValue(NotificationProperty);
            set { SetValue(NotificationProperty, value); }
        }
 

        public static readonly BindableProperty IconProperty = BindableProperty.Create
            (
            nameof(Icon),
            typeof(string),
            typeof(CardView),
            null, BindingMode.TwoWay
            );
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty BackgroundcolorProperty = BindableProperty.Create
            (
            nameof(Backgroundcolor),
            typeof(string),
            typeof(CardView),
            "#EFEFEF", BindingMode.TwoWay
            );
        public string Backgroundcolor
        {
            get => (string)GetValue(BackgroundcolorProperty);
            set { SetValue(BackgroundcolorProperty, value); }
        }

        public static readonly BindableProperty isVisibleProperty = BindableProperty.Create
            (
            nameof(isVisible),
            typeof(bool),
            typeof(CardView),
            false,
            BindingMode.TwoWay);
        public bool isVisible
        {
            get => (bool)GetValue(isVisibleProperty);
            set => SetValue(isVisibleProperty, value);
        }

        public static readonly BindableProperty ItemsSelectedProperty = BindableProperty.Create
            (
            nameof(ItemSelected),
            typeof(object),
            typeof(CardView),
            null,
            BindingMode.TwoWay);

        public object ItemSelected
        {
            get { return GetValue(ItemsSelectedProperty); }
            set { SetValue(ItemsSelectedProperty, value); }
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TitleProperty.PropertyName)
            {
                lblTitle.Text = Title;
            }
            if (propertyName == NotificationProperty.PropertyName)
            {
                lblNotifi.Text = Notification;
            }
            if (propertyName == IconProperty.PropertyName)
            {
                ImgIcon.Source = ImageSource.FromFile(Icon);
            }
            if (propertyName == BackgroundcolorProperty.PropertyName)
            {
                Container.BackgroundColor = Color.FromHex(Backgroundcolor);
            }
            if(propertyName==isVisibleProperty.PropertyName)
            {
                frmNotifi.IsVisible=isVisible;
            }
         
        }
        #endregion
        #region event custom
        private void OnTapped(object sender, EventArgs e)
        {
            OnSelected?.Invoke(sender,e);
        }
        #endregion
    }
}
