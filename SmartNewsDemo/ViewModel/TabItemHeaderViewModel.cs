using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace SmartNewsDemo.ViewModel
{
    public class TabItemHeaderViewModel: BaseViewModel
    {
        #region Properties, Variable
        public string btnTitle { get; set; }
        public string btnColor { get; set; }
        public string StackColor { get; set; }
        #endregion

        #region Command
        public ICommand TappedCommand { get; set; }
        #endregion
        public TabItemHeaderViewModel(string title, string color)
        {
            btnTitle = title;
            btnColor = color;
            TabViewViewModel.SelectedItemEvent += TabViewViewModel_SelectedItemEvent;
        }

        private void TabViewViewModel_SelectedItemEvent(object sender, string e)
        {
            StackColor = e;
        }
        
    }
}
