using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class TabItemMenuViewModel
    {
        #region properties
        public string NotificationNumber { get; set; }
        public bool NotiVisiable { get; set; }
        public string BackColor { get; set; }
        public bool isSelected;
        public static string Title;
        #endregion

        #region command
        public static event EventHandler<string> PassTitleName;
        public ICommand SelectedCardItemCommand { get; set; }
        #endregion
        public TabItemMenuViewModel()
        {
            SelectedCardItemCommand = new Command(HandleTapped);
            SetNotifiNumber();
        }

        private void HandleTapped(object obj)
        {
            var frm = (Frame)obj;
            frm.BackgroundColor = Color.FromHex("#C0C0C0");
            var lbl = frm.FindByName<Label>("lblTitle");
            Title = lbl.Text;
            EventHandler<string> handler = PassTitleName;
            handler?.Invoke(this, Title);
        }

        void SetNotifiNumber()
        {
            var number = HomeSettingViewModel.numberNoti;
            if (number > 99)
            {
                NotiVisiable = true;
                NotificationNumber = "99+";
            }
            else if (number < 1)
            {
                NotiVisiable = false;
            }
            else
            {
                NotiVisiable = true;
                NotificationNumber = number.ToString();
            }
        }
    }
}
