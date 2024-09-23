using JobPortal.DTO.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Job
{
    public interface IJobCityService
    {
        Task<GetJobCityDTO> GetJobCityByIdAsync(int id);
        Task<IEnumerable<GetJobCityDTO>> GetAllJobCitiesAsync();
        Task<GetJobCityDTO> CreateJobCityAsync(CreateJobCityDTO jobCity);
        Task<IEnumerable<GetJobCityDTO>> CreateJobCityAsync(IEnumerable<CreateJobCityDTO> jobCityDTOs);
        
        Task<GetJobCityDTO> UpdateJobCityAsync(long id, UpdateJobCityDTO jobCity);
        Task<bool> DeleteJobCityAsync(long id);

        Task<IEnumerable<GetJobCityViewModelDTO>> GetJobCityByJobIdAsync(long jobId);
    }
}
