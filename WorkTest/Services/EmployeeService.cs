using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTest.Models;
using WorkTest.Repository;

namespace WorkTest.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get employees in same department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        List<Employee> GetEmployees(int departmentId);

        /// <summary>
        /// Get all employees
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

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetEmployees(int departmentId)
        {
            return _employeeRepository.GetEmployees(departmentId);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee AddEmployee(Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        public void RemoveEmployee(int employeeId)
        {
            _employeeRepository.RemoveEmployee(employeeId);
        }
    }
}
