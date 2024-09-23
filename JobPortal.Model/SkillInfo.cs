using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model
{
    [Table("SkillInfos")]
    [Index(nameof(SkillId),nameof(UserId), IsUnique = true)]
    public class SkillInfo :BaseEntity
    { 
        public long SkillId { get; set; }

        // Navigation property for Skill
        [ForeignKey(nameof(SkillId))]
        public Skill  Skill { get; set; }


        public long ExpertLevelId { get; set; }

        // Navigation property for Skill
        [ForeignKey(nameof(ExpertLevelId))]
        public ExportLevel  ExportLevel { get; set; }

        // Foreign key to User
        public long UserId { get; set; }

        // Navigation property for User
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
