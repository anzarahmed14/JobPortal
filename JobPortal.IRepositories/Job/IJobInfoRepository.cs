using JobPortal.DTO.Job;
using JobPortal.Model;
using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories.Job
{
    public interface IJobInfoRepository : IRepository<JobInfo>
    {
         Task<JobInfo> GetJobInfoByIdAsync(long JobId);
         Task<IEnumerable<GetJobInfos>> GetJobInfosAsync();
        Task<IEnumerable<JobInfo>> SearchJobInfoAsync(List<long> jobIds, long designationId, long trainLineId);
    }
}
