using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ICompanyService
    {
        Task<GetCompanyDTO> CreateCompanyAsync(CreateCompanyDTO companyDTO);
        Task<bool> DeleteCompanyAsync(long id);
        Task<IEnumerable<GetCompanyDTO>> GetAllCitiesAsync();
        Task<GetCompanyDTO> GetCompanyByIdAsync(long id);
        Task<IEnumerable<GetCompanyDTO>> GetCitiesByStateIdAsync(long stateId);
        Task<GetCompanyDTO> UpdateCompanyAsync(long id, UpdateCompanyDTO companyDTO);
        Task<GetCompanyDTO> GetCompanyByUserIdAsync(long userId);
    }
}
