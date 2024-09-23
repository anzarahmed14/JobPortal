using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("AddressInfos")]
    public class AddressInfo : BaseEntity
    {
        //public AddressInfo()
        //{
        //    State = new State();
        //    Country = new Country();
        //    User = new User();
        //}

        //[Key]
        //public long Id { get; set; }
        public string Address { get; set; } = string.Empty;
        //public string City { get; set; } = string.Empty;


        public string PostalCode { get; set; } = string.Empty;



        //trainLineId


        // Foreign key to State
        public long TrainLineId { get; set; }
        // Navigation property for State
        [ForeignKey(nameof(TrainLineId))]
        public TrainLine TrainLine { get; set; }


        // Foreign key to State
        public long CityId { get; set; }
        // Navigation property for State
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }


        // Foreign key to State
        public long StateId { get; set; }
        // Navigation property for State
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }

        // Foreign key to Country
        public long CountryId { get; set; }
        // Navigation property for Country
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        // Foreign key to User
        public long UserId { get; set; }
        // Navigation property for User
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
