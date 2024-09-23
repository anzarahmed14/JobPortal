using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) {
            _companyRepository = companyRepository;
        }

        public Task<GetCompanyDTO> CreateCompanyAsync(CreateCompanyDTO companyDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCompanyAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCompanyDTO>> GetAllCitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCompanyDTO>> GetCitiesByStateIdAsync(long stateId)
        {
            throw new NotImplementedException();
        }

        public  Task<GetCompanyDTO> GetCompanyByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<GetCompanyDTO> UpdateCompanyAsync(long id, UpdateCompanyDTO companyDTO)
        {
            throw new NotImplementedException();
        }
        public async Task<GetCompanyDTO> GetCompanyByUserIdAsync(long userId)
        {
            try
            {
                // Define the expression to filter academic infos by userId
                Expression<Func<Company, bool>> expression = a => a.UserId == userId;

                // Call the repository method to get academic infos based on the expression
                var company = await _companyRepository.GetSingleOrDefaultAsync(expression);
                if (company != null)
                {
                    return MapToGetCompanyDTO(company);


                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private GetCompanyDTO MapToGetCompanyDTO(Company company)
        {
            return new GetCompanyDTO(company.Id, company.CompanyName, company.EmailAddress, company.MobileNo);
            
        }
    }
}
