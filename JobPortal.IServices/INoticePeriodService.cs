using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface INoticePeriodService
    {
        Task<List<GetNoticePeriodDTO>> GetAllNoticePeriodsAsync();
        Task<GetNoticePeriodDTO> GetNoticePeriodByIdAsync(long id);
        Task<long> AddNoticePeriodAsync(CreateNoticePeriodDTO createNoticePeriodDTO);
        Task UpdateNoticePeriodAsync(UpdateNoticePeriodDTO updateNoticePeriodDTO);
        Task DeleteNoticePeriodAsync(long id);
    }
}
