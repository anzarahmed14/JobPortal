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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<GetCityDTO> CreateCityAsync(CreateCityDTO cityDTO)
        {
            try
            {
                var city = new City
                {
                    CityName = cityDTO.CityName,
                    StateId = cityDTO.StateId
                };

                var newCity = await _cityRepository.CreateAsync(city);

                var newCityDTO = new GetCityDTO
                {
                    Id = newCity.Id,
                    CityName = newCity.CityName,
                  // StateId = newCity.StateId
                };

                return newCityDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCityAsync(long id)
        {
            try
            {
                var city = await _cityRepository.GetByIdAsync(id);
                if (city == null)
                {
                    throw new Exception($"City with ID {id} not found for delete.");
                }

                return await _cityRepository.DeleteAsync(city);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCityDTO>> GetAllCitiesAsync()
        {
            try
            {
                var cities = await _cityRepository.GetAllAsync();

                var citiesDTO = cities.Select(city => new GetCityDTO
                {
                    Id = city.Id,
                    CityName = city.CityName,
                   // StateId = city.StateId
                });

                return citiesDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCityDTO> GetCityByIdAsync(long id)
        {
            try
            {
                var city = await _cityRepository.GetByIdAsync(id);

                var cityDTO = new GetCityDTO
                {
                    Id = city.Id,
                    CityName = city.CityName,
                  //  StateId = city.StateId
                };

                return cityDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCityDTO>> GetCitiesByStateIdAsync(long stateId)
        {
            try
            {
                Expression<Func<City, bool>> expression = c => c.StateId == stateId;

                var cities = await _cityRepository.GetByConditionAsync(expression);

                var citiesDTO = cities.Select(city => new GetCityDTO
                {
                    Id = city.Id,
                    CityName = city.CityName,
                   // StateId = city.StateId
                });

                return citiesDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCityDTO> UpdateCityAsync(long id, UpdateCityDTO cityDTO)
        {
            try
            {
                var city = await _cityRepository.GetByIdAsync(id);
                if (city == null)
                {
                    throw new Exception($"City with ID {id} not found for update.");
                }

                city.CityName = cityDTO.CityName;
                city.StateId = cityDTO.StateId;

                var updatedCity = await _cityRepository.UpdateAsync(city);

                var updatedCityDTO = new GetCityDTO
                {
                    Id = updatedCity.Id,
                    CityName = updatedCity.CityName,
                  //  StateId = updatedCity.StateId
                };

                return updatedCityDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
