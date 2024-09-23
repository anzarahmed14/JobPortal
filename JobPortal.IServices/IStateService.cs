using JobPortal.DTO;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IStateService
    {
        Task<GetStateDTO> CreateStateAsync(CreateStateDTO stateDTO);
        Task<bool> DeleteStateAsync(long id);
        Task<IEnumerable<GetStateDTO>> GetAllStatesAsync();
        Task<GetStateDTO> GetStateByIdAsync(long id);
        Task<GetStateDTO> UpdateStateAsync(long id, UpdateStateDTO stateDTO);
    }
}
