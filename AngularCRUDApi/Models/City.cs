using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularCRUDApi.Models
{
    public class City
    {
        [Key]
        public int cityId { get; set; }
        [Required]
        public string cityName { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

    }
}
