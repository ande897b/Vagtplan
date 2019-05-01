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
            if (period == "1 måned")
            {
                newPeriod = Period.oneMonth;
            }
            else if (period == "3 måneder")
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
