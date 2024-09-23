using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("EmploymentInfos")]
    public class EmploymentInfo : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public new long Id { get; set; }

        // Fields related to employment details
        public double CurrentCTC { get; set; } // Cost To Company
       // public int NoticePeriod { get; set; } // Notice period in days
        public double ExpectedCTC { get; set; } // Expected Cost To Company


        // Foreign key to User
        public long NoticePeriodId { get; set; }
        // Navigation property for User
        [ForeignKey(nameof(NoticePeriodId))]
        public NoticePeriod  NoticePeriod { get; set; }


        // Foreign key to User
        public long UserId { get; set; }

        // Navigation property for User
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
