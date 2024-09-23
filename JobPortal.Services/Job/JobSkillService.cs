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
    public class JobSkillService : IJobSkillService
    {
        private IJobSkillRepository _jobSkillRepository;

        public JobSkillService(IJobSkillRepository jobSkillRepository) {
            _jobSkillRepository = jobSkillRepository;
        }
        public async Task<GetJobSkillDTO> CreateJobSkillAsync(CreateJobSkillDTO jobSkillDTO)
        {
            try
            {
                // Create a new JobSkill object from the provided DTO
                var jobSkill = new JobSkill
                {
                    SkillId = jobSkillDTO.SkillId,
                    JobId = jobSkillDTO.JobId
                };

                // Attempt to create the job skill using the repository
                await _jobSkillRepository.CreateAsync(jobSkill);

                // Return a GetJobSkillDTO with the created job skill's information
                return new GetJobSkillDTO(jobSkill.Id, jobSkill.SkillId, jobSkill.JobId);
            }
            catch (Exception)
            {
                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }
       
        public async Task<IEnumerable<GetJobSkillDTO>> CreateJobSkillAsync(IEnumerable<CreateJobSkillDTO> jobSkillDTOs)
        {
            var createdJobSkills = new List<GetJobSkillDTO>();

            try
            {
                /*always delete */
                var IsDeleted = await  _jobSkillRepository.DeleteJobSkillByJobIdAsync(jobSkillDTOs.Select(x=>x.JobId).FirstOrDefault());



                var jobSkills = jobSkillDTOs.Select(jobSkillDTO => new JobSkill
                {
                    SkillId = jobSkillDTO.SkillId,
                    JobId = jobSkillDTO.JobId
                }).ToList();

                // Attempt to create the job skills using the repository
                await _jobSkillRepository.CreateAsync(jobSkills);

                // Add the created job skills' information to the list
                foreach (var jobSkill in jobSkills)
                {
                    createdJobSkills.Add(new GetJobSkillDTO(jobSkill.Id, jobSkill.SkillId, jobSkill.JobId));
                }

                // Return a list of GetJobSkillDTOs with the created job skills' information
                return createdJobSkills;
            }
            catch (Exception)
            {
                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }

        public async Task<bool> DeleteJobSkillAsync(long id)
        {
            try
            {
                // Fetch the job skill by ID from the repository
                var jobSkill = await _jobSkillRepository.GetByIdAsync(id);

                if (jobSkill == null)
                {
                    // Log that the job skill wasn't found
                
                    return false;
                }

                // Delete the job skill using the repository
                await _jobSkillRepository.DeleteAsync(jobSkill);

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

        public async Task<IEnumerable<GetJobSkillDTO>> GetAllJobSkillsAsync()
        {
            try
            {
                // Get all job skills from the repository
                var jobSkills = await _jobSkillRepository.GetAllAsync();

                // Convert them to a list of GetJobSkillDTO objects
                return jobSkills.Select(js => new GetJobSkillDTO(js.Id, js.SkillId, js.JobId));
            }
            catch (Exception ex)
            {
              

                // Return an empty list to indicate failure
                return Enumerable.Empty<GetJobSkillDTO>();
            }
        }

        public async Task<GetJobSkillDTO> GetJobSkillByIdAsync(int id)
        {
            try
            {
                // Get the job skill by ID from the repository
                var jobSkill = await _jobSkillRepository.GetByIdAsync(id);

                if (jobSkill == null)
                {
                 
                    return null;
                }

                // Return the job skill information as a GetJobSkillDTO
                return new GetJobSkillDTO(jobSkill.Id, jobSkill.SkillId, jobSkill.JobId);
            }
            catch (Exception)
            {

                // Handle any exceptions that occur during the creation process
                // Log the exception details for further investigation
                throw;
            }
        }

        public async Task<IEnumerable<GetJobSkillViewModelDTO>> GetJobSkillByJobIdAsync(long jobId)
        {
            try
            {
                var jobSkills = await _jobSkillRepository.GetJobSkillByJobIdAsync(jobId);
                return jobSkills.Select(x => new GetJobSkillViewModelDTO(x.Id, x.SkillId,x.Skill.SkillName, x.JobId));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // You might want to throw a custom exception or return a default value
                // based on your application's requirements.
                Console.WriteLine($"An error occurred while retrieving job skills: {ex.Message}");
                throw;
            }
        }

        public async Task<GetJobSkillDTO> UpdateJobSkillAsync(long id, UpdateJobSkillDTO jobSkill)
        {
            try
            {
                // Get the job skill by ID from the repository
                var existingJobSkill = await _jobSkillRepository.GetByIdAsync(id);

                if (existingJobSkill == null)
                {
                    // Log that the job skill wasn't found
                  
                    return null;
                }

                // Update the job skill properties with values from the DTO
                existingJobSkill.SkillId = jobSkill.SkillId;
                existingJobSkill.JobId = jobSkill.JobId;

                // Update the job skill in the repository
                await _jobSkillRepository.UpdateAsync(existingJobSkill);

                // Return the updated job skill information as a GetJobSkillDTO
                return new GetJobSkillDTO(existingJobSkill.Id, existingJobSkill.SkillId, existingJobSkill.JobId);
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
