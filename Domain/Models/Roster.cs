using System;

namespace Domain.Models
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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Shop Shop { get; set; }
        public int RosterID { get; set; }


        public Roster(DateTime startDate, DateTime endDate, Shop shop)
        {
            RosterID = -1;
            StartDate = startDate;
            EndDate = endDate;
            Shop = shop;
        }
        public Roster(DateTime startDate, DateTime endDate, Shop shop, int rosterID)
        {
            RosterID = rosterID;
            StartDate = startDate;
            EndDate = endDate;
            Shop = shop;
        }
    }
}
