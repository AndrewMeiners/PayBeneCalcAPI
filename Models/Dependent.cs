using System.ComponentModel.DataAnnotations;

namespace BenefitsCalculatorAPI.Models
{
    public class Dependent
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
