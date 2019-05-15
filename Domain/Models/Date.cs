using System.Collections.Generic;
using System;

namespace Domain.Models
{
    public class Date
    {
        public DateTime Day { get; set; }
        public List<Duty> Duties { get; set; }
        public Shop Shop { get; set; }

        public Date (DateTime day, Shop shop)
        {
            Day = day;
            Shop = shop;
        }
        public Date(DateTime day, List<Duty> duties, Shop shop)
        {
            Day = day;
            Duties = duties;
            Shop = shop;
        }
    }
}