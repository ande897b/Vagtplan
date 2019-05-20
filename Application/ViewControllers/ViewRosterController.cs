using Domain.Models;
using Application.DatabaseControllers;
using Application.Repositories;
using System;
using System.Collections.Generic;

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
            List<Date> dates = DBRosterController.GetDates(shop);
            string newDate = date.Substring(0, 10);
            bool checkIfTrue = false;
            foreach (var day in dates)
            {
                string newDay = day.Day.ToString().Substring(0, 10);
                if (newDate == newDay)
                {
                    checkIfTrue = true;
                }
            }
            return checkIfTrue;
        }
    }
}
