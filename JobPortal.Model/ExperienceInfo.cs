using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("ExperienceInfos")]
    public class ExperienceInfo : BaseEntity
    {
        //public Experience()
        //{
        //    Designation = new Designation();
        //}

        //[Key]
        //  public long Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long DesignationId { get; set; }

        public string Description { get; set; }

        public bool IsCurrentlyWorking { get; set; }

        // Navigation property for Designation
        [ForeignKey(nameof(DesignationId))]
        public Designation Designation { get; set; }

        // Foreign key to User
        public long UserId { get; set; }

        // Navigation property for User
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
