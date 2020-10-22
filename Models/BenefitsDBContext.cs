using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalculatorAPI.Models
{
    public class BenefitsDBContext:DbContext
    {
        public BenefitsDBContext(DbContextOptions<BenefitsDBContext> options):base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
