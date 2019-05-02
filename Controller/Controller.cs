using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class Controller
    {
        public static void CreateRoster(DateTime startDate, DateTime endDate, string shop)
        {
            Shop newShop;
            if (shop == "kongensgade")
            {
                newShop = Shop.kongensgade;
            }
            else
            {
                newShop = Shop.skibhusvej;
            }

            Roster roster = new Roster(startDate, endDate, newShop);
            RosterDatabaseController.CreateRoster(roster);
            RosterRepository.AddRoster(roster);
        }
    }
}
