using Application.Repositories;
using Domain.Models;
using System.Data;
using System.Data.SqlClient;

namespace Application.DatabaseControllers
{
    public static class DBDutyExchangeController
    {
        public static void LoadDutyExchanges()
        {
            int dutyExchangeID = 0;
            int dutyID = 0;
            int employeeID = 0;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "SELECT * FROM DutyExchange";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dutyExchangeID = (int)reader["DutyExchangeID"];
                        dutyID = (int)reader["DutyID"];
                        employeeID = (int)reader["EmployeeID"];

                        DutyExchange newDutyExchange = new DutyExchange(dutyExchangeID, dutyID, employeeID);
                        DutyExchangeRepository.AddDutyExchange(newDutyExchange);
                    }
                    DBConnection.Close();
                }
            }
        }

        public static void CreateDutyExchange(DutyExchange dutyExchange)
        {
            DBConnection.DatabaseName = "CANE";
            string query = "Create_DutyExchange";

            if (!DutyExchangeRepository.DutyExchangeExist(dutyExchange))
            {
                if (DBConnection.IsConnected())
                {
                    var cmd = new SqlCommand(query, DBConnection.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DutyID_IN", dutyExchange.DutyID));
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID_IN", dutyExchange.EmployeeID));
                    cmd.ExecuteReader();
                }
                DBConnection.Close();
            }
            DutyExchangeRepository.AddDutyExchange(dutyExchange);
        }
       
        public static void DeleteDutyExchange(int dutyID, int employeeID)
        {
            DBConnection.DatabaseName = "CANE";
            string query = "Delete_DutyExchanges";

            if (DBConnection.IsConnected())
            {
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DutyID_IN", dutyID));
                cmd.Parameters.Add(new SqlParameter("@EmployeeID_IN", employeeID));
                cmd.ExecuteReader();
            }
            DBConnection.Close();
        }
    }    

}
