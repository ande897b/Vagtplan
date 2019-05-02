using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Roster2
    {
        public int RosterID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Shop Shop { get; set; }

        public Roster2(int rosterID, DateTime startDate, DateTime endDate, Shop shop)
        {
            RosterID = rosterID;
            StartDate = startDate;
            EndDate = endDate;
            Shop = shop;
        }
        public Roster2(DateTime startDate, DateTime endDate, Shop shop)
        {
            StartDate = startDate;
            EndDate = endDate;
            Shop = shop;
        }
    }
}
