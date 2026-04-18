using System.ComponentModel.DataAnnotations;

namespace Monocept.DTOs
{
    public class AgentDto
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}