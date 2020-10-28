using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BenefitsCalculatorAPI.Models;
using BenefitsCalculatorAPI.Services;

namespace BenefitsCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly BenefitsDBContext _context;
        private readonly CalculatorService calculatorService;
        public readonly EmployeeDAO employeeDAO;

        public EmployeeController(BenefitsDBContext context)
        {
            _context = context;
            calculatorService = new CalculatorService(_context);
            employeeDAO = new EmployeeDAO(_context);
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await employeeDAO.GetEmployees();
            return employees;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await employeeDAO.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employee/Cost/1
        [HttpGet("Cost/{id}")]
        public async Task<ActionResult<double>> GetEmployeeCost(int id)
        {
            return await calculatorService.CalculateEmployeePayrollAsync(id);
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }

            await employeeDAO.PutEmployee(id, employee);

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.ID }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await employeeDAO.DeleteEmployee(id);

            return employee;
        }
    }
}
