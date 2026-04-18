using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monocept.Models
{
    public class Policy
    {
        [Key]
        public int PolicyID { get; set; }

        public int CustomerID { get; set; }
        public int SchemeID { get; set; }

        public string PolicyDetails { get; set; }

        public decimal Premium { get; set; }

        public DateTime DateIssued { get; set; }

        public int MaturityPeriod { get; set; }

        public DateTime PolicyLapseDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("SchemeID")]
        public Scheme Scheme { get; set; }

        // Navigation
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}