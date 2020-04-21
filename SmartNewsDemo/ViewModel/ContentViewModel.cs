using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class ContentViewModel: BaseViewModel
    {
        #region Properties
        public string Link { get; set; }
        public string BackImage { get; set; }
        public string url;

        #endregion
        public ContentViewModel(string link)
        {
            Link = link;  
        }
    }
}
