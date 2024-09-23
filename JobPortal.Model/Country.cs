using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("Countries")]
    public class Country : BaseEntity
    {
        //[Key]
        //public long Id { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;

        // Navigation property for States
        public ICollection<State> States { get; set; } = new List<State>();
    }
}
