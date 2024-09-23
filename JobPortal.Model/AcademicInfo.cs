using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("AcademicInfos")] // Specify the table name
    public class AcademicInfo : BaseEntity
    {
        //AcademicInfo()
        //{
        //    User = new User();
        //}

       // [Key]
       // public long Id { get; set; }
        public string InstitutionName { get; set; } = string.Empty;
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public double Percentage { get; set; }
        public string Degree { get; set; } = string.Empty; /*bachelor */


        // Foreign key to User
        public long UserId { get; set; }
        // Navigation property for User
        public User User { get; set; }

    }
}
