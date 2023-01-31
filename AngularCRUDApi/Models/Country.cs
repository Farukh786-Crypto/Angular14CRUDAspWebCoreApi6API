using System.ComponentModel.DataAnnotations;

namespace AngularCRUDApi.Models
{
    public class Country
    {
        [Key]
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual IEnumerable<State>? States { get; set; }
    }
}
