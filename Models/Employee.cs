using System;
using System.ComponentModel.DataAnnotations;

namespace Monocept.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<EmployeeScheme> EmployeeSchemes { get; set; }
    }
}