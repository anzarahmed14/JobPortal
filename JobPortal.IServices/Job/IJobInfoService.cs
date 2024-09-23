using JobPortal.DTO;
using JobPortal.DTO.Job;
using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Job
{
    public interface IJobInfoService
    {
        Task<GetJobInfoViewModelDto> GetJobInfoByIdAsync(int id);
        Task<IEnumerable<GetJobInfoViewModelDtos>> GetAllJobInfosAsync();
        Task<GetJobInfoDto> CreateJobInfoAsync(CreateJobInfoDto jobInfo);
       
        Task<GetJobInfoDto> UpdateJobInfoAsync(long id, UpdateJobInfoDto jobInfo);
        Task<bool> DeleteJobInfoAsync(long id);
    }
}
