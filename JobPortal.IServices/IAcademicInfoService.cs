using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IAcademicInfoService
    {
        Task<GetAcademicInfoDto> CreateAcademicInfoAsync(CreateAcademicInfoDto academicInfoDTO);
        Task<bool> DeleteAcademicInfoAsync(long Id);
        Task<IEnumerable<GetAcademicInfoDto>> GetAllAcademicInfosAsync();
        Task<GetAcademicInfoDto> GetAcademicInfoByIdAsync(long Id);
        Task<GetAcademicInfoDto> UpdateAcademicInfoAsync(long Id,UpdateAcademicInfoDto academicInfoDTO);
        Task<IEnumerable<GetAcademicInfoDto>> GetAcademicInfosByUserIdAsync(long userId);
    }
}
