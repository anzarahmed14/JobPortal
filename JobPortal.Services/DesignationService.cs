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
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _cityRepository;

        public DesignationService(IDesignationRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<GetDesignationDTO> CreateDesignationAsync(CreateDesignationDTO cityDTO)
        {
            try
            {
                var designation = new Designation
                {
                    DesignationName = cityDTO.DesignationName,
                   
                };

                var newDesignation = await _cityRepository.CreateAsync(designation);

                var newDesignationDTO = new GetDesignationDTO
                {
                    Id = newDesignation.Id,
                    DesignationName = newDesignation.DesignationName,
                    
                };

                return newDesignationDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDesignationAsync(long id)
        {
            try
            {
                var designation = await _cityRepository.GetByIdAsync(id);
                if (designation == null)
                {
                    throw new Exception($"Designation with ID {id} not found for delete.");
                }

                return await _cityRepository.DeleteAsync(designation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetDesignationDTO>> GetAllCitiesAsync()
        {
            try
            {
                var cities = await _cityRepository.GetAllAsync();

                var citiesDTO = cities.Select(designation => new GetDesignationDTO
                {
                    Id = designation.Id,
                    DesignationName = designation.DesignationName,
                   // StateId = designation.StateId
                });

                return citiesDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetDesignationDTO> GetDesignationByIdAsync(long id)
        {
            try
            {
                var designation = await _cityRepository.GetByIdAsync(id);

                var cityDTO = new GetDesignationDTO
                {
                    Id = designation.Id,
                    DesignationName = designation.DesignationName,
                   // StateId = designation.StateId
                };

                return cityDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        public async Task<GetDesignationDTO> UpdateDesignationAsync(long id, UpdateDesignationDTO cityDTO)
        {
            try
            {
                var designation = await _cityRepository.GetByIdAsync(id);
                if (designation == null)
                {
                    throw new Exception($"Designation with ID {id} not found for update.");
                }

                designation.DesignationName = cityDTO.DesignationName;
              

                var updatedDesignation = await _cityRepository.UpdateAsync(designation);

                var updatedDesignationDTO = new GetDesignationDTO
                {
                    Id = updatedDesignation.Id,
                    DesignationName = updatedDesignation.DesignationName,
                   
                };

                return updatedDesignationDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
