using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monocept.Models
{
    public class Scheme
    {
        [Key]
        public int SchemeID { get; set; }

        public string SchemeName { get; set; }

        public string SchemeDetails { get; set; }

        // FK
        public int PlanID { get; set; }

        [ForeignKey("PlanID")]
        public InsurancePlan Plan { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Policy> Policies { get; set; }
        public ICollection<EmployeeScheme> EmployeeSchemes { get; set; }
    }
}