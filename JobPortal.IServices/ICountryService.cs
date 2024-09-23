using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ICountryService
    {

        Task<GetCountryDTO> CreateCountryAsync(CreateCountryDTO countryDTO);
        Task<bool> DeleteCountryAsync(long id);
        Task<IEnumerable<GetCountryDTO>> GetAllCountriesAsync();
        Task<GetCountryDTO> GetCountryByIdAsync(long id);
        Task<GetCountryDTO> UpdateCountryAsync(long id, UpdateCountryDTO countryDTO);
    }
}
