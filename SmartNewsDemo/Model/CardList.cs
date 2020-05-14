using System;
using System.Collections.Generic;

namespace SmartNewsDemo.Model
{
    public class Cards
    {
        public string CardTitle { get; set; }
        public string CardIcon { get; set; }

    }
    public class CardList
    {
        public List<Cards> Cards { get; set; }

    }
}
