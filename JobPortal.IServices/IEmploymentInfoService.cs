using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IEmploymentInfoService
    {
        Task<IEnumerable<GetEmploymentInfoDTO>> GetAllEmploymentInfosAsync();
        Task<GetEmploymentInfoDTO> GetEmploymentInfoByIdAsync(long id);
        Task<GetEmploymentInfoDTO> CreateEmploymentInfoAsync(CreateEmploymentInfoDTO employmentDetailDTO);
        Task<GetEmploymentInfoDTO> UpdateEmploymentInfoAsync(long id, UpdateEmploymentInfoDTO employmentDetailDTO);
        Task<bool> DeleteEmploymentInfoAsync(long id);
        Task<GetEmploymentInfoDTO> GetEmploymentInfosByUserIdAsync(long userId);
    }
}
