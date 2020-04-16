﻿using SmartNewsDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartNewsDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabItemHeaders : ContentPage
    {
        public TabItemHeaders(string title, string color)
        {
            InitializeComponent();
            this.BindingContext = new TabItemHeaderViewModel(title, color);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            frame.Margin = new Thickness(0,0,0,0);
            frame = new Frame();
        }
    }
}