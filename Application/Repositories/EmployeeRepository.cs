using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repositories
{
    public static class EmployeeRepository
    {
		private static List<Employee> employees = new List<Employee>();
		public static void AddEmployee(Employee employee)
		{
			employees.Add(employee);
		}
		public static List<Employee> GetEmployees()
		{
			return employees;
		}
		public static void RemoveEmployee(Employee employee)
		{
			employees.Remove(employee);
		}
        public static Employee GetEmployee(int id)
        {
            Employee tempEmp = null;
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == id)
                {
                    tempEmp = employee;
                }
            }
            return tempEmp;
        }
        public static int GetEmployeeID(string firstName)
        {
            int id = 0;
            foreach (Employee employee in employees)
            {
                if(employee.FirstName == firstName)
                {
                    id = employee.EmployeeID;
                }
            }
            return id;
        }
    }
}
