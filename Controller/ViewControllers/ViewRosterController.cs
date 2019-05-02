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
            RosterRepository.AddRoster(roster);
        }
    }
}
