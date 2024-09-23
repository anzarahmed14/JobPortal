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
    public class JobCityRepository : Repository<JobCity>, IJobCityRepository
    {
        public JobCityRepository(JobPortalDbContext context) : base(context)
        {
        }

        //public async Task<bool> DeleteJobCityByJobIdAsync(long jobId)
        //{
        //    var citiesToDelete = _context.JobCities.AsNoTracking().Where(x => x.JobId == jobId);
        //    _context.JobCities.RemoveRange(citiesToDelete);
        //    int rowsAffected = await _context.SaveChangesAsync();
        //    return rowsAffected > 0;
        //}
        public async Task<bool> DeleteJobCityByJobIdAsync(long jobId)
        {
            if (_context == null)
            {
                // Log or handle the null context case appropriately
                return false; // Or throw an exception if required
            }

            var citiesToDelete = await _context.JobCities.AsNoTracking().Where(x => x.JobId == jobId).ToListAsync();

            if (citiesToDelete.Count== 0 )
            {
                // Log or handle the case where cities to delete is null
                return false; // Or throw an exception if required
            }

            _context.JobCities.RemoveRange(citiesToDelete);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<JobCity>> GetJobCityByJobIdAsync(long JobId)
        {
            try
            {
                var jobCities = await _context.JobCities
                                               .AsNoTracking()
                                               .Include(js => js.City) // Include the Skill navigation property
                                               .Where(x => x.JobId == JobId)
                                               .ToListAsync();

                return jobCities;
            }
            catch (Exception )
            {
                throw;
            }
        }

    }
}
