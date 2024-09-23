using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("States")]
    public class State : BaseEntity
    {

        //public State()
        //{
        //    Country = new Country();
        //}

        //[Key]
        //public long Id { get; set; }
        public string StateName { get; set; } = string.Empty;
        public string StateCode { get; set; } = string.Empty;

        // Foreign key to Country
        public long CountryId { get; set; }
        // Navigation property for Country
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
    }
}
