using Microsoft.EntityFrameworkCore;

namespace BenefitsCalculatorAPI.Models
{
    public class BenefitsDBContext:DbContext
    {
        public BenefitsDBContext(DbContextOptions<BenefitsDBContext> options):base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Dependent> Dependent { get; set; }
    }
}
