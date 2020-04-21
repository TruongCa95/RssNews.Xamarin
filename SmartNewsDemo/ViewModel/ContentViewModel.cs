﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class ContentViewModel
    {
        #region Properties
        public string Link { get; set; }
        public string BackImage { get; set; }
        #endregion
        #region Command
        public ICommand RefreshWVcommand { get; set; }
        #endregion
        public ContentViewModel(string link)
        {
            Link = link;
            
        }
    }
}
