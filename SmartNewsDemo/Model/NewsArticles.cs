using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SmartNewsDemo.Model
{
    public class NewsArticles : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Updated { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Provider { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public partial class NewsArctileEx : NewsArticles
    {
    }

}
