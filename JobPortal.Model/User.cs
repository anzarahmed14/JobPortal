using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("Users")]
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class User : BaseEntity
    {
        
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Navigation property for PersonalInfo
        public PersonalInfo PersonalInfo { get; set; }


        // Foreign key to State
        public long RoleId { get; set; }
        // Navigation property for Role
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
