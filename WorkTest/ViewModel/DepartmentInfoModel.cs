using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTest.Models;

namespace WorkTest.ViewModel
{
    public class DepartmentInfoModel
    {
        public string DepartmentName { get; set; }
        public int EmployeesCount { get; set; }
        public decimal AverageSalary { get; set; }
        public List<string> EmployeeNames { get; set; }
        public string CurrentEmployeeName { get; set; }

        public DepartmentInfoModel() { }

        public DepartmentInfoModel(List<Employee> employees, int currentEmployeeId)
        {
            if (employees?.Count > 0)
            {
                DepartmentName = employees[0].Department.Name;
                EmployeesCount = employees.Count;
                AverageSalary = employees.Average(e => e.Salary);
                EmployeeNames = employees.Select(e => e.Name).ToList();
                CurrentEmployeeName = employees.FirstOrDefault(e => e.Id == currentEmployeeId)?.Name;
            }
        }
    }
}
