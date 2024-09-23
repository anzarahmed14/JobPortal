using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories.Job
{
    public interface IJobCityRepository : IRepository<JobCity>
    {
         Task<bool> DeleteJobCityByJobIdAsync(long jobId);
        Task<IEnumerable<JobCity>> GetJobCityByJobIdAsync(long JobId);
    }
}
