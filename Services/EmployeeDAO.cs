using BenefitsCalculatorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalculatorAPI.Services
{
    public class EmployeeDAO
    {
        private readonly BenefitsDBContext _context;

        public EmployeeDAO(BenefitsDBContext context) 
        { 
            _context = context; 
        }

        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employee.Include(e => e.Dependents).ToListAsync();
        }

        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            //var employee = await _context.Employee.FindAsync(id);
            var employee = await _context.Employee.Include(e => e.Dependents).FirstOrDefaultAsync(e => e.ID == id);

            if (employee == null)
            {
                return null;
            }

            return employee;
        }

        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                // Check before call
                //return BadRequest();
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
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return null;
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
