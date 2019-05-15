using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repositories
{
	public static class RosterRepository
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
		public static DateTime GetEndDate(string shop)
		{
			DateTime endDate = DateTime.Now;
			int i = rosters.Count;
			while (endDate == DateTime.Now)
			{
				if (rosters[i-1].Shop.ToString().ToLower() == shop)
				{
					endDate = rosters[i-1].EndDate;
				}
				i--;
			}
			return endDate;
		}
		public static bool CurrentRosterExist(string shop)
		{
			bool exists = false;

			foreach (Roster roster in rosters)
			{
				if (roster.Shop.ToString().ToLower() == shop)
				{
					exists = true;
				}
			}
			return exists;
		}
        public static bool CheckIfExists(DateTime date)
        {
            bool exists = false;            

            List<Roster> rosters = GetRosters();

            for (int i = 0; i < rosters.Count; i++)
            {
                DateTime start = rosters[i].StartDate;
                DateTime[] dates = new DateTime[360];

                for (int j = 0; start <= rosters[i].EndDate; j++)
                {
                    dates[j] = start;
                    start = start.AddDays(1);
                    if (start == date)
                    {
                        exists = true;
                    }
                }
            }
            return exists;
        }
	}
}