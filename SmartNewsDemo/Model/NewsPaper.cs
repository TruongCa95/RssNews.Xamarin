using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartNewsDemo.Model
{
    public class NewsPaper
    {
        public string NewsTitle { get; set; }
        public string NewsIcon { get; set; }
        public List<string> NewsCategory { get; set; }
        public List<string> NewsCategoryColor { get; set; }
    }
}
