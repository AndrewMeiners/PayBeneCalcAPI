using BenefitsCalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalculatorAPI.Services
{
    public class CalculatorService
    {
        private readonly BenefitsDBContext _context;

        // These could be abstracted out into different rules to be applied
        private double paycheck = 2000;
        private double payPeriods = 26;
        private double discountRate = 0.9;
        private double employeeCost = 1000;
        private double perDependentCost = 500;
        private double totalDependentCost = 0;

        public CalculatorService(BenefitsDBContext context)
        {
            _context = context;
        }

        public async Task<double> CalculateEmployeePayrollAsync(int id)
        {
            double adjustedEmployeeCost = 1000;
            // Need to include the Dependents to Eager load related
            var employee = await _context.Employee.Include(e => e.Dependents).FirstOrDefaultAsync(e => e.ID == id);

            if (employee == null)
            {
                return 0;
            }

            if (employee.FirstName.StartsWith('A'))
            {
                adjustedEmployeeCost = employeeCost * discountRate;
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

            return (paycheck * payPeriods) - adjustedEmployeeCost - totalDependentCost;
        }
    }
}
