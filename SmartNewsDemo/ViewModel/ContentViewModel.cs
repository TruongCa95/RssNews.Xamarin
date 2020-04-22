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
        public bool lblVisiable { get; set; }
        #endregion
        #region command
        public ICommand webviewNavigatedCommand { get; set; }
        public ICommand webviewNavigatingCommand { get; set; }
        #endregion
        public ContentViewModel(string link)
        {
            Link = link;
            webviewNavigatedCommand = new Command(HandleNavigated);
            webviewNavigatingCommand = new Command(HandleNavigating);
        }

        private void HandleNavigating(object obj)
        {
            lblVisiable = true;
        }

        private void HandleNavigated(object obj)
        {
            lblVisiable = false;
        }
    }
}
