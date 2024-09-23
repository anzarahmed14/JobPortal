using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("Skills")]
    [Index(nameof(SkillName), IsUnique = true)]
    public class Skill:BaseEntity
    {
        public string SkillName { get; set; }
        public bool IsActive { get; set; }=false;

        // Foreign key property
        public long SkillCategoryId { get; set; }

        // Navigation property
        [ForeignKey(nameof(SkillCategoryId))]
        public virtual SkillCategory SkillCategory { get; set; }
    }
}
