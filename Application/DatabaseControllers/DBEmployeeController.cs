using Application;
using Application.Repositories;
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
    public static class DBEmployeeController
    {
        public static void LoadEmployees()
        {
            int employeeID;
            string rank = null;
            string firstName = null;
            string lastName = null;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, DBConnection.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeID = (int)reader["EmployeeID"];

                        rank = reader["EmployeeRank"].ToString();
                        Rank newRank;
                        if (rank == "Parttimer")
                        {
                            newRank = Rank.parttimer;
                        }
                        else
                        {
                            newRank = Rank.manager;
                        }

                        firstName = reader["FirstName"].ToString();
                        lastName = reader["LastName"].ToString();

                        Employee employee = new Employee(employeeID, firstName, lastName, newRank);
                        EmployeeRepository.AddEmployee(employee);
                    }
                }
                DBConnection.Close();
            }
        }

        public static int GetEmployeeID(Employee employee)
        {
            int ID = 0;

            DBConnection.DatabaseName = "CANE";
            if (DBConnection.IsConnected())
            {
                string query = "Get_Employee";
                var cmd = new SqlCommand(query, DBConnection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("FirstName_IN", employee.FirstName));
                cmd.Parameters.Add(new SqlParameter("LastName_IN", employee.LastName));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        ID = (int)reader["EmployeeID"];
                    }
                }
                DBConnection.Close();
            }
            return ID;
        }
    }
}
