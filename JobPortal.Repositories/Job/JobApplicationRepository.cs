using JobPortal.Data;
using JobPortal.DTO.RequestDTO;
using JobPortal.IRepositories.Job;
using JobPortal.Model.Job;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories.Job
{
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(JobPortalDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationsAsync(JobApplicationRequestDto jobApplicationRequestDto)
        {
           
            try
            {
                var query = _context.JobApplications.AsNoTracking()
                                                    .Include(s => s.User)
                                                    .Include(s => s.JobInfo)
                                                        .ThenInclude(j => j.Company) // Include Company through JobInfo
                                                    .AsQueryable();

                if (jobApplicationRequestDto.jobId > 0)
                {
                    query = query.Where(j=>j.JobInfo.Id == jobApplicationRequestDto.jobId); 
                }

                // Execute the query and return the filtered results
                var jobApplications = await query.ToListAsync();

              

                return jobApplications;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving job applications", ex);
            }
        }
    }
}
