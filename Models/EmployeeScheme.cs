using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monocept.Models
{
    public class EmployeeScheme
    {
        [Key]
        public int EmployeeSchemeID { get; set; }

        public int EmployeeID { get; set; }
        public int SchemeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        [ForeignKey("SchemeID")]
        public Scheme Scheme { get; set; }
    }
}