using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using Database;

namespace Controller
{
    public static class RosterDatabaseController
    {
        public static List<Roster> GetRosters(Roster roster)
        {
            List<Roster> rosterList = new List<Roster>();
            string rosterID = null;
            string period = null;
            string shop = null;

            DBConnection.DatabaseName = "EALSQL1.eal.local";
            if (DBConnection.IsConnect())
            {
                string query = "SELECT * FROM Roster";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rosterID = reader["RosterID"].ToString();
                        int.TryParse(rosterID, out int rosterIDint);

                        period = reader["PeriodID"].ToString();
                        int.TryParse(period, out int periodID);
                        Period newPeriod;
                        if (periodID == 1)
                        {
                            newPeriod = Period.oneMonth;
                        }
                        else if (periodID == 3)
                        {
                            newPeriod = Period.threeMonth;
                        }
                        else
                        {
                            newPeriod = Period.twoMonth;
                        }

                        shop = reader["Shop"].ToString();
                        Shop newShop;
                        if (shop == "kongensgade")
                        {
                            newShop = Shop.kongensgade;
                        }
                        else
                        {
                            newShop = Shop.skibhusvej;
                        }

                        Roster addRoster = new Roster(rosterIDint, newPeriod, newShop);
                        RosterRepository.AddRoster(addRoster);
                        rosterList.Add(addRoster);
                    }
                }
                DBConnection.Close();
            }
            return rosterList;
        }
        public static void CreateRoster(Roster roster)
        {

        }
        public static void DeleteRoster(Roster roster)
        {

        }
    }
}
