using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Job
{
    [Table("JobCities")]
    public class JobCity : BaseEntity
    {

        // Foreign key to JobInfo
        public long JobId { get; set; }
        // Navigation property for JobInfo
        [ForeignKey(nameof(JobId))]
        public JobInfo JobInfo { get; set; }

        // Foreign key to SkillId
        public long CityId { get; set; }
        // Navigation property for Skill
        [ForeignKey(nameof(CityId))]
        public City  City { get; set; }
    }
}
