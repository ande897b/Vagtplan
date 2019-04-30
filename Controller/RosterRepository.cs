using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    static class RosterRepository
    {
        private static List<Roster> rosters = new List<Roster>();
        public static void AddRoster(Roster roster)
        {
            rosters.Add(roster);
        }
        public static List<Roster> GetRosters()
        {
            return rosters;
        }
        public static void RemoveRoster()
        {
            
        }
    }
}
