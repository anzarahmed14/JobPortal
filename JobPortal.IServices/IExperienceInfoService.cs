using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IExperienceInfoService
    {
        Task<IEnumerable<GetExperienceInfoDTO>> GetAllExperienceInfosAsync();
        Task<GetExperienceInfoDTO> GetExperienceInfoByIdAsync(long Id);


        Task<GetExperienceInfoDTO> CreateExperienceInfoAsync(CreateExperienceInfoDTO experienceDTO);
        Task<GetExperienceInfoDTO> UpdateExperienceInfoAsync(long Id, UpdateExperienceInfoDTO experienceDTO);
        Task<bool> DeleteExperienceInfoAsync(long Id);
        Task<IEnumerable<GetExperienceInfosDTO>> GetExperienceInfosByUserIdAsync(long userId);
      // Task<IEnumerable<GetExperienceInfoDTO>> GetExperienceInfoByUserIdAsync(long userId);
    }
}
