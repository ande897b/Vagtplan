using System.Collections.Generic;
using Domain.Models;

namespace Application.Repositories
{
	public static class EmployeeRepository
	{
		private static List<Employee> employees = new List<Employee>();
		public static void AddEmployee(Employee employee)
		{
			if (!EmployeeExist(employee))
				employees.Add(employee);
		}

		public static bool EmployeeExist(Employee employee)
		{
			bool exist = false;
			foreach (Employee employee2 in employees)
			{
				if (employee2.FirstName == employee.FirstName && employee2.LastName == employee.LastName)
				{
					if (employee2.EmployeeID != employee.EmployeeID)
					{
						employee2.EmployeeID = employee.EmployeeID;
					}
					exist = true;
				}
			}
			return exist;
		}

		public static List<Employee> GetEmployees()
		{
			return employees;
		}

		public static Employee GetEmployee(int employeeID)
		{
			Employee tempEmp = null;
			foreach (Employee employee in employees)
			{
				if (employee.EmployeeID == employeeID)
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
