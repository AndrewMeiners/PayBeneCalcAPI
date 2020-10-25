using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalculatorAPI.Models
{
    public class Dependent
    {
        [Key]
        public int dependentId { get; set; }

        public int providerId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string dependentName { get; set; }
    }
}
