using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ICityService
    {
        Task<GetCityDTO> CreateCityAsync(CreateCityDTO cityDTO);
        Task<bool> DeleteCityAsync(long id);
        Task<IEnumerable<GetCityDTO>> GetAllCitiesAsync();
        Task<GetCityDTO> GetCityByIdAsync(long id);
        Task<IEnumerable<GetCityDTO>> GetCitiesByStateIdAsync(long stateId);
        Task<GetCityDTO> UpdateCityAsync(long id, UpdateCityDTO cityDTO);
    }
}
