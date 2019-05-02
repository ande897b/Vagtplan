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
	}
}
