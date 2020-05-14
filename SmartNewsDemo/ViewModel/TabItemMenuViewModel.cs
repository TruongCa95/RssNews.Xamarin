using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using SmartNewsDemo.View;
using System.Reflection;
using SmartNewsDemo.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SmartNewsDemo.ViewModel
{
    public class TabItemMenuViewModel : BaseViewModel
    {
        #region properties
        public List<Cards> Cards { get; set; }
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
            string path = @"Common/Storage";
            string fullpath = Path.GetFullPath(path);
            Console.WriteLine("getfullpath('{0}') return '{1}", path, fullpath);
            //GetJsonData("ListCardData.json");          
        }
        private List<Cards> GetJsonData(string jsonFileName)
        {
            CardList ObjCardList = new CardList();
            
            //var b = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //var a = Path.Combine(b, @"Common\Storage"+ jsonFileName);
            //var assembly = typeof(HomeMenu).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    var jsonString = reader.ReadToEnd();

            //    //Converting JSON Array Objects into generic list    
            //    ObjCardList = JsonConvert.DeserializeObject<CardList>(jsonString);
            //}
            //Binding listview with json string     
            return ObjCardList.Cards;
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
        public override Task OnAppearing()
        {
            NotiVisiable = true;
            return base.OnAppearing();
        }
    }
}
