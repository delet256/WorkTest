using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkTest.Models;

namespace WorkTest.Repository
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get employees in same department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        List<Employee> GetEmployees(int departmentId);
        
        /// <summary>
        /// Getall employees
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployees();

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee AddEmployee(Employee employee);

        /// <summary>
        /// Edit current employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee UpdateEmployee(Employee employee);

        /// <summary>
        /// Remove current employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        void RemoveEmployee(int employeeId);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly WorkDBContext _context;

        public EmployeeRepository(WorkDBContext db)
        {
            _context = db;
        }

        public List<Employee> GetEmployees(int departmentId)
        {
            return _context.Employees.Include(e => e.Department).Where(e => e.DepartmentId == departmentId).ToList();
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }

        public void RemoveEmployee(int employeeId)
        {
            _context.Remove(employeeId);
            _context.SaveChanges();
        }
    }
}
