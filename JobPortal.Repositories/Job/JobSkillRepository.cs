using JobPortal.Data;
using JobPortal.DTO.Job;
using JobPortal.IRepositories.Job;
using JobPortal.Model;
using JobPortal.Model.Job;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories.Job
{
    public class JobSkillRepository : Repository<JobSkill>, IJobSkillRepository
    {
        public JobSkillRepository(JobPortalDbContext context) : base(context)
        {
        }

        public async Task<bool> DeleteJobSkillByJobIdAsync(long jobId)
        {
            var skillsToDelete = _context.JobSkills.Where(x => x.JobId == jobId);
            _context.JobSkills.RemoveRange(skillsToDelete);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<JobSkill>> GetJobSkillByJobIdAsync(long JobId)
        {
            try
            {
                var jobSkills = await _context.JobSkills
                                               .AsNoTracking()
                                               .Include(js => js.Skill) // Include the Skill navigation property
                                               .Where(x => x.JobId == JobId)
                                               .ToListAsync();

                return jobSkills;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // You might want to throw a custom exception or return a default value
                // based on your application's requirements.
                Console.WriteLine($"An error occurred while retrieving job skills: {ex.Message}");
                throw;
            }
        }

    }
}
