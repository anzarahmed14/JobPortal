using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories.Job
{
    public interface IJobSkillRepository : IRepository<JobSkill>
    {
         Task<bool> DeleteJobSkillByJobIdAsync(long jobId);
        Task<IEnumerable<JobSkill>> GetJobSkillByJobIdAsync(long JobId);
    }
}
