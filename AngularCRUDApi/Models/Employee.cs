using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularCRUDApi.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required,EmailAddress]
        public string? email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
