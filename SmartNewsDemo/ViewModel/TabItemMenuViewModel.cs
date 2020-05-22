using Newtonsoft.Json;
using SmartNewsDemo.Model;
using SmartNewsDemo.Utilitis.Extension_Method;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class TabItemMenuViewModel : BaseViewModel
    {
        #region properties
        public ObservableCollection<Cards> Cards { get; set; }
        public Cards ItemSelected { get; set; }
        public string NotificationNumber { get; set; }
        public bool NotiVisiable { get; set; }
        public Color BackColor { get; set; }
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
            SetData();
        }

        private void SetData()
        {
            var jsonString = ReadAndWriteFile.GetJsonData("ListCardData.json");
            var result = JsonConvert.DeserializeObject<List<Cards>>(jsonString);
            Cards = new ObservableCollection<Cards>(result);
        }

        private void HandleTapped(object obj)
        {
            var frm = (Frame)obj;
            frm.BackgroundColor = Color.FromHex("#C0C0C0");
            //get element child
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
