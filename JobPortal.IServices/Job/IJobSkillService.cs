using JobPortal.DTO.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Job
{
    public interface IJobSkillService
    {
        Task<GetJobSkillDTO> GetJobSkillByIdAsync(int id);
        Task<IEnumerable<GetJobSkillDTO>> GetAllJobSkillsAsync();
        Task<GetJobSkillDTO> CreateJobSkillAsync(CreateJobSkillDTO jobSkill);
        Task<IEnumerable<GetJobSkillDTO>> CreateJobSkillAsync(IEnumerable<CreateJobSkillDTO> jobSkillDTOs);
        

            Task<GetJobSkillDTO> UpdateJobSkillAsync(long id, UpdateJobSkillDTO jobSkill);
        Task<bool> DeleteJobSkillAsync(long id);

        Task<IEnumerable<GetJobSkillViewModelDTO>> GetJobSkillByJobIdAsync(long jobId);
    }
}
