using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Job
{
    [Table("JobInfos")]
    public class JobInfo:BaseEntity
    {
        public long Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int MinimumSalary { get; set; }
        public int MaximumSalary { get; set; }


        // Foreign key to DesignationId
        public long TrainLineId { get; set; }

        // Navigation property for User
        [ForeignKey(nameof(TrainLineId))]
        public TrainLine TrainLine { get; set; }


        // Foreign key to DesignationId
        public long DesignationId { get; set; }

        // Navigation property for User
        [ForeignKey(nameof(DesignationId))]
        public Designation  Designation { get; set; }

        // Navigation Property
        public virtual ICollection<JobCity> JobCities { get; set; }// = new List<JobCity>();

        // Navigation Property
        public virtual ICollection<JobSkill> JobSkills { get; set; }// = new List<JobSkill>();




        // Foreign key to Company
        public long CompanyId { get; set; }

        // Navigation property for Company
        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }// =  new Company ();

    }
}
