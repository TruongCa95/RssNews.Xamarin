using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class ContentViewModel: BaseViewModel
    {
        #region Properties
        public string Link { get; set; }
        public bool Busy { get; set; }
        public bool btnVisable { get; set; }
        public bool MoreVisible { get; set; }
        public bool imgbtnVisible { get; set; }
        public int CountClick = 1;
        #endregion
        #region command
        public ICommand WebviewNavigatedCommand { get; set; }
        public ICommand WebviewNavigatingCommand { get; set; }
        public ICommand ShowHideCommand { get; set; }
        public ICommand OpenBroserCommand { get; set; }
        public ICommand ShareLinkCommand { get; set; }
        public ICommand ShowMoreLayoutCommand { get; set; }
        public ICommand FocusCommand { get; set; }
        #endregion
        public ContentViewModel(string link)
        {
            
            Link = link;
            WebviewNavigatedCommand = new Command(HandleNavigated);
            WebviewNavigatingCommand = new Command(HandleNavigating);
            ShowHideCommand = new Command(HandleShowHideButton);
            ShowMoreLayoutCommand = new Command(HandleShowMoreLayout);
            OpenBroserCommand = new Command(HandleOpenBrowser);
            ShareLinkCommand = new Command(HandleShareLink);
            FocusCommand = new Command(HandleFocused);
            imgbtnVisible = true;
            MoreVisible = false;
            btnVisable = false;
        }

        #region event
        private void HandleFocused(object obj)
        {
            MoreVisible = false;
            imgbtnVisible = true;
        }

        private async void HandleShareLink(object obj)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = Link
            });
            MoreVisible = false;
            imgbtnVisible = true;
        }

        private async void HandleOpenBrowser(object obj)
        {
            await Browser.OpenAsync(Link, BrowserLaunchMode.SystemPreferred);
            MoreVisible = false;
            imgbtnVisible = true;
        }

        private void HandleShowMoreLayout(object obj)
        {
            imgbtnVisible = false;
            MoreVisible = true;
        }

        private void HandleShowHideButton(object obj)
        {
            CountClick ++;
            MoreVisible = false;
            imgbtnVisible = true;
            if (CountClick % 2 == 0)
            {
                btnVisable = true;
            }
            else
                btnVisable = false;
        }

        private void HandleNavigating(object obj)
        {
            Busy = true;
        }

        private void HandleNavigated(object obj)
        {
            Busy = false;
        }
        #endregion
    }
}
