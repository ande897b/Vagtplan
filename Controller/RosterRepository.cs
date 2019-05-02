using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class RosterRepository
    {
        private static int count = 0;
        private static List<Roster> rosters = new List<Roster>();
        public static void AddRoster(Roster roster)
        {
            rosters.Add(roster);
        }
        public static List<Roster> GetRosters()
        {
            return rosters;
        }
        public static void RemoveRoster(Roster roster)
        {
			rosters.Remove(roster);
        }
        public static int GetCountOfRosterMonths()
        {
            
            foreach (var roster in rosters)
            {
                if (roster.Period == Period.oneMonth)
                {
                    count += 1;
                }
                if (roster.Period == Period.twoMonth)
                {
                    count += 2;
                }
                else
                {
                    count += 3;
                }
               
            }
            return count;
        }
    }
}
