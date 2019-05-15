using Domain.Models;
using Application.DatabaseControllers;
using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewControllers
{
    public static class ViewRosterController
    {
        public static void CreateRoster(DateTime startDate, DateTime endDate, string shop)
        {
            Shop newShop;
            if (shop == Shop.kongensgade.ToString())
            {
                newShop = Shop.kongensgade;
            }
            else
            {
                newShop = Shop.skibhusvej;
            }


            Roster roster = new Roster(startDate, endDate, newShop);
            DBRosterController.CreateRoster(roster);
            int rosterID = DBRosterController.GetRosterID(roster);
            DBRosterController.CreateDateList(rosterID, shop);
            int dateListID = DBRosterController.GetDateListID(rosterID, shop);
            DBRosterController.CreateDates(dateListID, shop, startDate, endDate);

            RosterRepository.AddRoster(roster);
        }
        public static bool CheckIfDateExists(string date,string shop)
        {
            bool checkIfTrue = false;
            foreach (var day in DBRosterController.GetDates(shop))
            {
                if (date == day.Day.ToString())
                {
                    checkIfTrue = true;

                }
            }
            return checkIfTrue;
      
        }


    }
}
