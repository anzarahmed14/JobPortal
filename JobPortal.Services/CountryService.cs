using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<GetCountryDTO> CreateCountryAsync(CreateCountryDTO countryDTO)
        {
            var countryEntity = MapToEntity(countryDTO);
            var createdCountryEntity = await _countryRepository.CreateAsync(countryEntity);
            return MapToDTO(createdCountryEntity);
        }

        public async Task<bool> DeleteCountryAsync(long id)
        {
            var existingCountryEntity = await _countryRepository.GetByIdAsync(id);
            if (existingCountryEntity == null)
                return false;

            return await _countryRepository.DeleteAsync(existingCountryEntity);
        }

        public async Task<IEnumerable<GetCountryDTO>> GetAllCountriesAsync()
        {
            var countryEntities = await _countryRepository.GetAllAsync();
            return countryEntities.Select(MapToDTO);
        }

        public async Task<GetCountryDTO> GetCountryByIdAsync(long id)
        {
            var countryEntity = await _countryRepository.GetByIdAsync(id);
            return countryEntity != null ? MapToDTO(countryEntity) : null;
        }

        public async Task<GetCountryDTO> UpdateCountryAsync(long id, UpdateCountryDTO countryDTO)
        {
            var existingCountryEntity = await _countryRepository.GetByIdAsync(id);
            if (existingCountryEntity == null)
                return null;

            existingCountryEntity.CountryName = countryDTO.CountryName;
            existingCountryEntity.CountryCode = countryDTO.CountryCode;

            var updatedCountryEntity = await _countryRepository.UpdateAsync(existingCountryEntity);
            return MapToDTO(updatedCountryEntity);
        }

        private GetCountryDTO MapToDTO(Country countryEntity)
        {
            return new GetCountryDTO
            {
                Id = countryEntity.Id,
                CountryName = countryEntity.CountryName,
                CountryCode = countryEntity.CountryCode
            };
        }

        private Country MapToEntity(CreateCountryDTO countryDTO)
        {
            return new Country
            {
                CountryName = countryDTO.CountryName,
                CountryCode = countryDTO.CountryCode
            };
        }

        private GetCountryDTO MapToDTO(UpdateCountryDTO countryDTO)
        {
            return new GetCountryDTO
            {
                Id = countryDTO.Id,
                CountryName = countryDTO.CountryName,
                CountryCode = countryDTO.CountryCode
            };
        }
    }
}
