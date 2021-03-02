using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTest.Models;

namespace WorkTest.ViewModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public DepartmentModel Department { get; set; }

        public EmployeeModel() { }

        public EmployeeModel(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Salary = employee.Salary;
            Department = employee.Department == null
                ? new DepartmentModel {Id = employee.DepartmentId}
                : new DepartmentModel(employee.Department);
        }

        public Employee PushToEmployee()
        {
            return new Employee
            {
                Id = Id,
                Name = Name,
                Salary = Salary,
                DepartmentId = Department.Id
            };
        }
    }
}
