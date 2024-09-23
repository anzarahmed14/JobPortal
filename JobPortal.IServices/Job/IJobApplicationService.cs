using JobPortal.DTO.Job;
using JobPortal.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Job
{
    public interface IJobApplicationService
    {
        Task<GetJobApplicationDto> GetJobApplicationByIdAsync(int id);
        Task<IEnumerable<GetJobApplicationViewDto>> GetJobApplicationsAsync(JobApplicationRequestDto jobApplicationRequestDto);
        Task<GetJobApplicationDto> CreateJobApplicationAsync(CreateJobApplicationDto jobApplication);
        Task<IEnumerable<GetJobApplicationDto>> CreateJobApplicationAsync(IEnumerable<CreateJobApplicationDto> jobApplicationDTOs);
        Task<GetJobApplicationDto> UpdateJobApplicationAsync(long id, UpdateJobApplicationDto jobApplication);
        Task<bool> DeleteJobApplicationAsync(long id);

        
    }
}
