﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class TabItemHeaderViewModel: BaseViewModel
    {
        #region Properties, Variable
        public string btnTitle { get; set; }
        public string btnColor { get; set; }
        public Thickness MarginPancake { get; set; }
        public Thickness PaddingStack { get; set; }
        public string StackColor { get; set; }
        #endregion

        #region Command
        public ICommand TappedCommand { get; set; }
        #endregion
        public TabItemHeaderViewModel(string title, string color)
        {
            btnTitle = title;
            btnColor = color;
            MarginPancake = new Thickness(0, 10, 0, 10);
            PaddingStack = new Thickness(0, 0, 0, 8);
            TabViewViewModel.TappedItemEvent += TabViewViewModel_TappedItemEvent;
        }

        private void TabViewViewModel_TappedItemEvent(object sender, string e)
        {
            StackColor = e;
            //MarginPancake = new Thickness(0, 5, 0, 5);
            //PaddingStack = new Thickness(0, 0, 0, 1);
            
        }
    }
}
