using System;
namespace SmartNewsDemo.Model
{
    public partial class NewsArctile:NewsArticles
    {
        public DateTime ConvertDate => DateTime.Parse(Updated);
        public string CustomDate
        {
            get
            {
                var date = DateTime.Now - ConvertDate;
                if (date.TotalDays >= 1)
                    return date.Days.ToString() + " yesterday";
                if (date.TotalHours >= 1)
                    return date.Hours.ToString() + " hours ago";
                if (date.TotalMinutes >= 1)
                    return date.Minutes.ToString() + " Minutes ago";
                if (date.TotalSeconds >= 1)
                    return date.Seconds.ToString() + " Seconds ago";
                return string.Empty;
            }
        }
    }
}
