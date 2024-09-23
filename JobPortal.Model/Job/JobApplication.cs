using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Model.Job
{
    //
    [Table("JobApplications")]
    // Define unique constraint on UserId and JobId
    [Index(nameof(UserId), nameof(JobId), IsUnique = true)]
    public class JobApplication : BaseEntity
    {

        // Foreign key to JobInfo
        public long JobId { get; set; }
        // Navigation property for JobInfo
        [ForeignKey(nameof(JobId))]
        public virtual JobInfo JobInfo { get; set; } //=  new JobInfo ();




        // Foreign key to JobInfo
        public long UserId { get; set; }
        // Navigation property for JobInfo
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } //= new User();
        public DateTime ApplyDate { get; set; }  =  DateTime.Now;

    }
}
