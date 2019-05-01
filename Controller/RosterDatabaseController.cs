using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using Database;
using System.Data;

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

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnect())
            {
                string query = "SELECT * FROM Roster";
                SqlCommand cmd = new SqlCommand(query, DBConnection.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rosterID = reader["RosterID"].ToString();
                        int.TryParse(rosterID, out int rosterIDint);

                        period = reader["Period"].ToString();

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
            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnect())
            {
                string query = "Create_Roster";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Period_IN", roster.Period));
                cmd.Parameters.Add(new SqlParameter("@Shop_IN", roster.Shop));
                cmd.ExecuteReader();
                DBConnection.Close();
            }
        }
        public static void DeleteRoster(Roster roster)
        {

        }
    }
}
