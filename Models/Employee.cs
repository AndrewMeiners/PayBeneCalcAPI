using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenefitsCalculatorAPI.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public List<Dependent> Dependents { get; set; }
    }
}
