using System.ComponentModel.DataAnnotations;

namespace HRIS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required , MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Phone { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Status { get; set; } = "Hired";


    }
}
