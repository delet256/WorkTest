using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTest.Models;

namespace WorkTest.ViewModel
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        
        public DepartmentModel() { }

        public DepartmentModel(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Salary = department.Salary;
        }

    }
}
