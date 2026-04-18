using System;
using System.ComponentModel.DataAnnotations;

namespace Monocept.Models
{
    public class InsuranceAgent
    {
        [Key]
        public int AgentID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}