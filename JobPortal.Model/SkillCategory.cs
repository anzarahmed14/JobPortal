using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("SkillCategories")]
    [Index(nameof(SkillCategoryName), IsUnique = true)]
    public class SkillCategory : BaseEntity
    {
        public string SkillCategoryName { get; set; }
        public bool IsActive { get; set; } = false;

        // Navigation property
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
