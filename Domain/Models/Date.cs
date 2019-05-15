using System.Collections.Generic;
using System;

namespace Domain.Models
{
    public class Date
    {
        public DateTime Day { get; set; }

        public Shop Shop { get; set; }
        public int DateID { get; set; }
        public int DateListId { get; set; }

        public Date (DateTime day, Shop shop)
        {
            Day = day;
            Shop = shop;
        }
        public Date(DateTime day, int dateID,int dateListID, Shop shop)
        {
            Day = day;
            DateID = dateID;
            DateListId = dateListID;
            Shop = shop;
        }
    }
}