using JobPortal.DTO.Job;
using JobPortal.IRepositories.Job;
using JobPortal.IServices.Job;
using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Job
{
    public class JobCityService : IJobCityService
    {
        private IJobCityRepository _jobCityRepository;

        public JobCityService(IJobCityRepository jobCityRepository) {
            _jobCityRepository = jobCityRepository;
        }
        public async Task<GetJobCityDTO> CreateJobCityAsync(CreateJobCityDTO jobCityDto)
        {
            try
            {
                // Create a new JobCity object from the provided DTO
                var jobCity = new JobCity
                {
                    CityId = jobCityDto.CityId,
                    JobId = jobCityDto.JobId
                };

                // Attempt to create the job City using the repository
                await _jobCityRepository.CreateAsync(jobCity);

                // Return a GetJobCityDTO with the created job City's information
                return new GetJobCityDTO(jobCity.Id, jobCity.CityId, jobCity.JobId);
            }
            catch (Exception)
            {
                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }
       
        public async Task<IEnumerable<GetJobCityDTO>> CreateJobCityAsync(IEnumerable<CreateJobCityDTO> jobCityDTOs)
        {
            var createdJobCities = new List<GetJobCityDTO>();

            try
            {
                /*always delete */
                var IsDeleted = await  _jobCityRepository.DeleteJobCityByJobIdAsync(jobCityDTOs.Select(x=>x.JobId).FirstOrDefault());



                var jobCities = jobCityDTOs.Select(jobCityDTO => new JobCity
                {
                    CityId = jobCityDTO.CityId,
                    JobId = jobCityDTO.JobId
                }).ToList();

                // Attempt to create the job Citys using the repository
                await _jobCityRepository.CreateAsync(jobCities);

                // Add the created job Citys' information to the list
                foreach (var jobCity in jobCities)
                {
                    createdJobCities.Add(new GetJobCityDTO(jobCity.Id, jobCity.CityId, jobCity.JobId));
                }

                // Return a list of GetJobCityDTOs with the created job Citys' information
                return createdJobCities;
            }
            catch (Exception)
            {
                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }

        public async Task<bool> DeleteJobCityAsync(long id)
        {
            try
            {
                // Fetch the job City by ID from the repository
                var jobCity = await _jobCityRepository.GetByIdAsync(id);

                if (jobCity == null)
                {
                    // Log that the job City wasn't found
                
                    return false;
                }

                // Delete the job City using the repository
                await _jobCityRepository.DeleteAsync(jobCity);

                // Return true to indicate successful deletion
                return true;
            }
            catch (Exception)
            {
                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }

        public async Task<IEnumerable<GetJobCityDTO>> GetAllJobCitiesAsync()
        {
            try
            {
                // Get all job Citys from the repository
                var jobCitys = await _jobCityRepository.GetAllAsync();

                // Convert them to a list of GetJobCityDTO objects
                return jobCitys.Select(js => new GetJobCityDTO(js.Id, js.CityId, js.JobId));
            }
            catch (Exception ex)
            {
              

                // Return an empty list to indicate failure
                return Enumerable.Empty<GetJobCityDTO>();
            }
        }

        public async Task<GetJobCityDTO> GetJobCityByIdAsync(int id)
        {
            try
            {
                // Get the job City by ID from the repository
                var jobCity = await _jobCityRepository.GetByIdAsync(id);

                if (jobCity == null)
                {
                 
                    return null;
                }

                // Return the job City information as a GetJobCityDTO
                return new GetJobCityDTO(jobCity.Id, jobCity.CityId, jobCity.JobId);
            }
            catch (Exception)
            {

                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }

        public async Task<IEnumerable<GetJobCityViewModelDTO>> GetJobCityByJobIdAsync(long jobId)
        {
            try
            {
                var jobCitys = await _jobCityRepository.GetJobCityByJobIdAsync(jobId);
                return jobCitys.Select(x => new GetJobCityViewModelDTO(x.Id, x.CityId,x.City.CityName, x.JobId));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // You might want to throw a custom exception or return a default value
                // based on your application's requirements.
                Console.WriteLine($"An error occurred while retrieving job Citys: {ex.Message}");
                throw;
            }
        }

        public async Task<GetJobCityDTO> UpdateJobCityAsync(long id, UpdateJobCityDTO jobCity)
        {
            try
            {
                // Get the job City by ID from the repository
                var existingJobCity = await _jobCityRepository.GetByIdAsync(id);

                if (existingJobCity == null)
                {
                    // Log that the job City wasn't found
                  
                    return null;
                }

                // Update the job City properties with values from the DTO
                existingJobCity.CityId = jobCity.CityId;
                existingJobCity.JobId = jobCity.JobId;

                // Update the job City in the repository
                await _jobCityRepository.UpdateAsync(existingJobCity);

                // Return the updated job City information as a GetJobCityDTO
                return new GetJobCityDTO(existingJobCity.Id, existingJobCity.CityId, existingJobCity.JobId);
            }
            catch (Exception)
            {

                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }
    }
}
