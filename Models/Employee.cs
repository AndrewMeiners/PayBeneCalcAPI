using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalculatorAPI.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string employeeName { get; set; }

        public int dependentCount { get; set; }
    }
}
