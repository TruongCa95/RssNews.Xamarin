using System;
using System.Collections.Generic;
using System.Text;

namespace SmartNewsDemo.ViewModel
{
   public class ContentViewModel
    {
        #region Properties
        public string Link { get; set; }
        #endregion
        public ContentViewModel(string link)
        {
            Link = link;
        }
    }
}
