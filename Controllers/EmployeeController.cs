using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BenefitsCalculatorAPI.Models;
using Newtonsoft.Json;

namespace BenefitsCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly BenefitsDBContext _context;

        public EmployeeController(BenefitsDBContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.Include(e => e.Dependents).ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            //var employee = await _context.Employee.FindAsync(id);
            var employee = await _context.Employee.Include(e => e.Dependents).FirstOrDefaultAsync(e => e.ID == id);

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
            double paycheck = 2000;
            double payPeriods = 26;
            double discountRate = 0.9;
            double employeeCost = 1000;
            double perDependentCost = 500;
            double totalDependentCost = 0;

            // Need to include the Dependents to Eager load related
            var employee = await _context.Employee.Include(e => e.Dependents).FirstOrDefaultAsync(e => e.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            if (employee.FirstName.StartsWith('A'))
            {
                employeeCost *= discountRate;
            }

            if (employee.Dependents != null)
            {
                foreach (Dependent dependent in employee.Dependents)
                {
                    if (dependent.FirstName.StartsWith('A'))
                    {
                        totalDependentCost += (perDependentCost * discountRate);
                    }
                    else
                    {
                        totalDependentCost += perDependentCost;
                    }
                }
            }
            
            return (paycheck * payPeriods) - employeeCost - totalDependentCost;
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

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }
    }
}
