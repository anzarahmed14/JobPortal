using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IPersonalInfoService
    {
        Task<GetPersonalInfoDTO> CreatePersonalInfoAsync(CreatePersonalInfoDTO personalInfoDTO);
        Task<bool> DeletePersonalInfoAsync(long Id);
        Task<IEnumerable<GetPersonalInfoDTO>> GetAllPersonalInfosAsync();
        Task<GetPersonalInfoDTO> GetPersonalInfoByIdAsync(long id);
        Task<GetPersonalInfoDTO> UpdatePersonalInfoAsync(long Id, UpdatePersonalInfoDTO personalInfoDTO);

        Task<GetPersonalInfoDTO> GetPersonalInfoByUserIdAsync(long userId);
    }
}
