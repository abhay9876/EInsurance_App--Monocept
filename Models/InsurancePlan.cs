using System;
using System.ComponentModel.DataAnnotations;

namespace Monocept.Models
{
    public class InsurancePlan
    {
        [Key]
        public int PlanID { get; set; }

        public string PlanName { get; set; }

        public string PlanDetails { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Scheme> Schemes { get; set; }
    }
}