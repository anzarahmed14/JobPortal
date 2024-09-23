using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ISkillInfoService
    {
        Task<GetSkillInfoDTO> CreateSkillInfoAsync(CreateSkillInfoDTO SkillInfoDTO);
        Task<IEnumerable<GetSkillInfoDTO>> CreateSkillInfoAsync(IEnumerable<CreateSkillInfoDTO> SkillInfoDTO);
        Task<bool> DeleteSkillInfoAsync(long Id);
        Task<IEnumerable<GetSkillInfoDTO>> GetAllSkillInfosAsync();
        Task<GetSkillInfoDTO> GetSkillInfoByIdAsync(long Id);
        Task<IEnumerable< GetSkillInfoDTOs>> GetSkillInfosByUserIdAsync(long userId);
        Task<GetSkillInfoDTO> UpdateSkillInfoAsync(long Id, UpdateSkillInfoDTO SkillInfoDTO);


    }
}
