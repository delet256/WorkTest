using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTest.Services;
using WorkTest.ViewModel;

namespace WorkTest.Controllers
{
    [Route("api/[controller]/[action]")]

    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return new JsonResult(employees.Select(e => new EmployeeModel(e)));
        }

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeModel employee)
        {
            var result =  _employeeService.AddEmployee(employee.PushToEmployee());

            return new JsonResult(result);
        }

        /// <summary>
        /// Edit current employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateEmployee([FromBody] EmployeeModel employee)
        {
            var result = _employeeService.UpdateEmployee(employee.PushToEmployee());

            return new JsonResult(result);
        }
        /// <summary>
        /// Remove current employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        [HttpPost]
        public IActionResult RemoveEmployee([FromBody] int employeeId)
        {
            _employeeService.RemoveEmployee(employeeId);

            return Ok();
        }
    }
}
