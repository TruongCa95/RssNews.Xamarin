using System;
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
        public double Height { get; set; }
        #endregion

        #region Command
        #endregion
        public TabItemHeaderViewModel(string title, string color)
        {
            btnTitle = title;
            btnColor = color;
        }
    }
}
