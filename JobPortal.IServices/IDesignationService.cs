using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IDesignationService
    {
        Task<GetDesignationDTO> CreateDesignationAsync(CreateDesignationDTO cityDTO);
        Task<bool> DeleteDesignationAsync(long id);
        Task<IEnumerable<GetDesignationDTO>> GetAllCitiesAsync();
        Task<GetDesignationDTO> GetDesignationByIdAsync(long id);
 
        Task<GetDesignationDTO> UpdateDesignationAsync(long id, UpdateDesignationDTO cityDTO);
    }
}
