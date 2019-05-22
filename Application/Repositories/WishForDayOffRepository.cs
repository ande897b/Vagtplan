using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Repositories
{
    public static class WishForDayOffRepository
    {
        private static List<WishForDayOff> wishForDayOffList = new List<WishForDayOff>();
        public static void AddWishForDayOff(WishForDayOff wishForDayOff)
        {
            wishForDayOffList.Add(wishForDayOff);
        }
        public static List<WishForDayOff> GetWishForDayOffs()
        {
            return wishForDayOffList;
        }
        public static void RemoveWishForDayOff(WishForDayOff wishForDayOff)
        {
            wishForDayOffList.Remove(wishForDayOff);
        }
        public static List<WishForDayOff> GetWishForDayOffs(string date)
        {
            List<WishForDayOff> newListOfWishes = new List<WishForDayOff>();
            foreach (WishForDayOff wish in wishForDayOffList)
            {
                if (wish.Date.ToString().Substring(0,10) == date.Substring(0,10))
                {
                    newListOfWishes.Add(wish);
                }
            }
            return newListOfWishes;
        }

    }
}
