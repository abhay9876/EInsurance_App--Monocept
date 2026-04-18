using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monocept.Models
{
    public class Commission
    {
        [Key]
        public int CommissionID { get; set; }

        public int AgentID { get; set; }
        public int PolicyID { get; set; }

        public decimal CommissionAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("AgentID")]
        public InsuranceAgent Agent { get; set; }

        [ForeignKey("PolicyID")]
        public Policy Policy { get; set; }
    }
}