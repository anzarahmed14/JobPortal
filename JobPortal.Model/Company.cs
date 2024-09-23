using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{

    [Table("Companies")]
    public class Company : BaseEntity
    { 
        
        public string CompanyName { get; set; } =string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;



        // Foreign key to User
        public long UserId { get; set; }

        // Navigation property for User
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
