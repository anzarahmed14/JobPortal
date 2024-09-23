using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Roles")]
    [Index(nameof(RoleCode), IsUnique = true)]
    public class Role:BaseEntity
    {
        [Required(ErrorMessage = "Enter role name")]
        [MaxLength(100)]
        public string RoleName { get; set; }= string.Empty;
        [Required(ErrorMessage = "Enter role code")]
        [MaxLength(10)]
        public string RoleCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
