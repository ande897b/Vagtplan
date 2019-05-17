using System.Collections.Generic;
using System;

namespace Domain.Models
{
    public class Date
    {
        public DateTime Day { get; set; }

        public Shop Shop { get; set; }
        public int DateID { get; set; }
        public int RosterID { get; set; }

        public Date(DateTime day, int dateID,int rosterID, Shop shop)
        {
            Day = day;
            DateID = dateID;
            RosterID = rosterID;
            Shop = shop;
        }
    }
}