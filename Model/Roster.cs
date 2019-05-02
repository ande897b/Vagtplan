using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Shop
    {
        skibhusvej,
        kongensgade
    }
    public enum Period
    {
        oneMonth,
        twoMonth,
        threeMonth
    }
    
    public class Roster
    {
        public int RosterID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Shop Shop { get; set; }

        public Roster(int rosterID, DateTime startDate, DateTime endDate, Shop shop)
        {
            RosterID = rosterID;
            StartDate = startDate;
            EndDate = endDate;
            Shop = shop;
        }
        public Roster(DateTime startDate, DateTime endDate, Shop shop)
        {
            StartDate = startDate;
            EndDate = endDate;
            Shop = shop;
        }
    }
}
