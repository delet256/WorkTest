using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkTest.Services;
using WorkTest.ViewModel;

namespace WorkTest.Controllers
{
    [Route("api/[controller]/[action]")]

    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IEmployeeService _employeeService;

        public DepartmentController(ILogger<DepartmentController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult GetDepartmentInfo([FromBody] EmployeeModel employee)
        {
            var employees = _employeeService.GetEmployees(employee.Department.Id);

            return new JsonResult(new DepartmentInfoModel(employees, employee.Id));

        }
    }
}
