using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monocept.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        public int CustomerID { get; set; }
        public int PolicyID { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("PolicyID")]
        public Policy Policy { get; set; }
    }
}