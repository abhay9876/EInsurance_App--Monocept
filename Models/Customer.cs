using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monocept.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        // FK
        public int AgentID { get; set; }

        [ForeignKey("AgentID")]
        public InsuranceAgent Agent { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Policy> Policies { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}