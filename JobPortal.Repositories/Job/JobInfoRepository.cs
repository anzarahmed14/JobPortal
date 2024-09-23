using JobPortal.Data;
using JobPortal.DTO.Job;
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
    public class JobInfoRepository : Repository<JobInfo>, IJobInfoRepository
    {
        public JobInfoRepository(JobPortalDbContext context) : base(context)
        {
        }

        public async Task<JobInfo> GetJobInfoByIdAsync(long JobId)
        {
            try
            {
                var jobInfo = await _context.JobInfos
                                               .AsNoTracking()
                                               .Include(js => js.Designation) // Include the Skill navigation property
                                               .Include(js => js.TrainLine) // Include the Skill navigation property
                                               .Where(x => x.Id == JobId).FirstOrDefaultAsync();
                                               

                return jobInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<JobInfo>> SearchJobInfoAsync(List<long> jobIds, long designationId, long trainLineId)
        {
            try
            {

                var query = _context.JobInfos
                    .AsNoTracking()
                    .Include(js => js.Designation) // Include the Designation navigation property
                    .Include (js => js.Company)
                    .Include(js => js.TrainLine)   // Include the TrainLine navigation property
                    .Include(js => js.JobCities)   // Include the JobCities navigation property
                        .ThenInclude(js=>js.City)
                    .Include(js => js.JobSkills)
                        .ThenInclude(js => js.Skill) // Include Skill related to JobSkills to get SkillName
                    .AsQueryable();

                // Conditionally filter by JobIds if jobIds is not empty
                if (jobIds != null && jobIds.Count > 0)
                {
                    query = query.Where(x => jobIds.Contains(x.Id));
                }

                // Conditionally filter by DesignationId if it's greater than 0
                if (designationId > 0)
                {
                    query = query.Where(x => x.DesignationId == designationId);
                }

                // Conditionally filter by TrainLineId if it's greater than 0
                if (trainLineId > 0)
                {
                    query = query.Where(x => x.TrainLineId == trainLineId);
                }

                // Execute the query and return the filtered results
                var jobInfos = await query.ToListAsync();
                return jobInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<GetJobInfos>> GetJobInfosAsync()
        {
            try
            {
                var jobInfos = await _context.JobInfos
                    .AsNoTracking()
                    .Include(js => js.Designation)
                    .Include(js => js.TrainLine)
                    .Select(js => new GetJobInfos(js, _context.JobSkills.Count(s => s.JobId == js.Id), _context.JobCities.Count(l => l.JobId == js.Id), _context.JobApplications.Count(c=>c.JobId == js.Id
                    )))
                    .ToListAsync();

                return jobInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
