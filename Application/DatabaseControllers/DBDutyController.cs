using Application;
using Controller.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.DatabaseControllers
{
    public static class DBDutyController
    {
        public static void LoadDuties()
        {
            int employeeID ;
            DateTime startTime;
            DateTime endTime;
            int dateID;
            int dutyID;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "SELECT * FROM Duty";
                SqlCommand cmd = new SqlCommand(query, DBConnection.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeID = (int)reader["EmployeeID"];
                        dateID = (int)reader["DateID"];
                        dutyID = (int)reader["DutyID"];
                        startTime = (DateTime)reader["StartTime"];
                        endTime = (DateTime)reader["EndTime"];

                        Duty duty = new Duty(dutyID, employeeID, dateID, startTime, endTime);
                        DutyRepository.AddDuty(duty);
                    }
                }
                DBConnection.Close();
            }
        }

        public static void CreateDuty(Duty duty)
        {
            string query = "Create_Duty";
            DBConnection.DatabaseName = "CANE";
            if (!DutyRepository.DutyExist(duty))
            {
                if (DBConnection.IsConnected())
                {
                    var cmd = new SqlCommand(query, DBConnection.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID_IN", duty.EmployeeID));
                    cmd.Parameters.Add(new SqlParameter("@DateID_IN", duty.DateID));
                    cmd.Parameters.Add(new SqlParameter("@StartTime_IN", duty.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@EndTime_IN", duty.EndTime));
                    cmd.ExecuteReader();
                    DBConnection.Close();
                }
                
                DutyRepository.AddDuty(duty);
            }
        }

        public static void DeleteDuties(int dateID)
        {
            string query = "Delete_Duties";
            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DateID_IN", dateID));
                cmd.ExecuteReader();
                DBConnection.Close();
            }
            
        }
    }
}
