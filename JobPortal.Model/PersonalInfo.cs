using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("PersonalInfos")] // Specify the table name
    public class PersonalInfo : BaseEntity
    {
        //public PersonalInfo()
        //{
        //    User = new User();
        //}
        // public long Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // Foreign key to User
        public long UserId { get; set; }

        // Navigation property for User
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
