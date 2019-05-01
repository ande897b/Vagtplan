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
        public static void CreateRoster(string period, string shop)
        {
            Period newPeriod;
            if (period == "oneMonth")
            {
                newPeriod = Period.oneMonth;
            }
            else if (period == "threeMonth")
            {
                newPeriod = Period.threeMonth;
            }
            else
            {
                newPeriod = Period.twoMonth;
            }

            Shop newShop;
            if (shop == "kongensgade")
            {
                newShop = Shop.kongensgade;
            }
            else
            {
                newShop = Shop.skibhusvej;
            }

            Roster roster = new Roster(newPeriod, newShop);
            RosterDatabaseController.CreateRoster(roster);
        }
    }
}
