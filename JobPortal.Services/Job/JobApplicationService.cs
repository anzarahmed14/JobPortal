using JobPortal.DTO.Job;
using JobPortal.DTO.RequestDTO;
using JobPortal.IRepositories;
using JobPortal.IRepositories.Job;
using JobPortal.IServices;
using JobPortal.IServices.Job;
using JobPortal.Model;
using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Job
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IPersonalInfoService  _personalInfoService;
        public JobApplicationService(IJobApplicationRepository jobApplicationRepository, IPersonalInfoService personalInfoService) {
            _jobApplicationRepository = jobApplicationRepository;
            _personalInfoService = personalInfoService;
        }
        public async Task<GetJobApplicationDto> CreateJobApplicationAsync(CreateJobApplicationDto jobApplicationDto)
        {

            var jobApplication =  new JobApplication() {  ApplyDate = jobApplicationDto.ApplyDate, JobId = jobApplicationDto.JobId, UserId = jobApplicationDto.UserId};
            
            var addedJobApplicationDto = await   _jobApplicationRepository.CreateAsync(jobApplication);

            return new GetJobApplicationDto(addedJobApplicationDto.Id);
        }

        public Task<IEnumerable<GetJobApplicationDto>> CreateJobApplicationAsync(IEnumerable<CreateJobApplicationDto> jobApplicationDTOs)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteJobApplicationAsync(long id)
        {
            throw new NotImplementedException();
        }

       
        public async Task<IEnumerable<GetJobApplicationViewDto>> GetJobApplicationsAsync(JobApplicationRequestDto jobApplicationRequestDto)
        {
            var jobApplications = await _jobApplicationRepository.GetJobApplicationsAsync(jobApplicationRequestDto);

            // Create a list to hold the results
            var result = new List<GetJobApplicationViewDto>();

            // Iterate over each job application
            foreach (var application in jobApplications)
            {
                // Retrieve personal info for the user
                var personalInfo = await _personalInfoService.GetPersonalInfoByUserIdAsync(application.UserId);

                if (personalInfo != null)
                {
                    // Add the result to the list
                    result.Add(new GetJobApplicationViewDto(
                        application.JobId,
                        application.JobInfo.JobTitle,
                        personalInfo.FirstName,
                        personalInfo.LastName,
                        application.JobInfo.Company.CompanyName
                    ));

                }

            }

            return result;
        }

        public Task<GetJobApplicationDto> GetJobApplicationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetJobApplicationDto> UpdateJobApplicationAsync(long id, UpdateJobApplicationDto jobApplication)
        {
            throw new NotImplementedException();
        }
    }
}
