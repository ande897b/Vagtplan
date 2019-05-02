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
		public static int GetEmployeeID(Employee employee)
		{
			return employee.EmployeeID;
		}
		public static List<Employee> GetEmployees()
		{
			return employees;
		}
		public static void RemoveEmployee(Employee employee)
		{
			employees.Remove(employee);
		}
    }
}
