using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Job
{
   public record GetJobApplicationDto(long Id);
   public record CreateJobApplicationDto(long JobId, long UserId, DateTime ApplyDate);
   public record UpdateJobApplicationDto();

   public record GetJobApplicationViewDto(long jobId, string jobTitle, string firstName, string lastName, string companyName);

}
