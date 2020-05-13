using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class TabItemMenuViewModel
    {
        public string NotificationNumber { get; set; }
        public bool NotiVisiable { get; set; }
        public string BackColor { get; set; }
        public ICommand SelectedCardItemCommand { get; set; }
        public bool isSelected;
        public static string Title;
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
