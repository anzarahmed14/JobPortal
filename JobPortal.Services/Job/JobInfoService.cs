using JobPortal.DTO.Job;
using JobPortal.IRepositories;
using JobPortal.IRepositories.Job;
using JobPortal.IServices;
using JobPortal.IServices.Job;
using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Job
{
    public class JobInfoService: IJobInfoService
    {
        private readonly IJobInfoRepository _jobInfoRepository;
        private readonly ICompanyService _companyService;
     
        public JobInfoService(IJobInfoRepository jobInfoRepository, ICompanyService companyService)
        {
            _jobInfoRepository = jobInfoRepository;
            _companyService = companyService;
        }

        public async Task<GetJobInfoDto> CreateJobInfoAsync(CreateJobInfoDto jobInfoDto)
        {
            if (jobInfoDto == null)
            {
                throw new ArgumentNullException(nameof(jobInfoDto), "Job information cannot be null.");
            }


           var compnayByUserId = await _companyService.GetCompanyByUserIdAsync(jobInfoDto.UserId);
            if (compnayByUserId == null)
            {
                throw new ArgumentNullException(nameof(jobInfoDto), $"Company not found for this user {jobInfoDto.UserId} ");
            }


            var jobInfo = new JobInfo
            {
                JobTitle = jobInfoDto.JobTitle,
                JobDescription = jobInfoDto.JobDescription,
                MinimumSalary = jobInfoDto.MinimumSalary,
                MaximumSalary = jobInfoDto.MaximumSalary,
                TrainLineId = jobInfoDto.TrainLineId,
                DesignationId = jobInfoDto.DesignationId,
                CompanyId = compnayByUserId.Id,

            };

            try
            {
                await _jobInfoRepository.CreateAsync(jobInfo);
            }
            catch (Exception ex)
            {
                // Log the exception (assuming a logging framework is in place)
                throw new InvalidOperationException("An error occurred while creating job information.", ex);
            }

            // Assuming CreateAsync populates jobInfo.Id or returns the created entity with its ID
            return new GetJobInfoDto(
                jobInfo.Id,
                jobInfo.JobTitle,
                jobInfo.JobDescription,
                jobInfo.MinimumSalary,
                jobInfo.MaximumSalary,
                jobInfo.TrainLineId,
                jobInfo.DesignationId
            );
        }


        public async Task<bool> DeleteJobInfoAsync(long id)
        {
            var jobInfo = await _jobInfoRepository.GetByIdAsync(id);
            if (jobInfo == null)
            {
                // If the jobInfo with the given id doesn't exist, return false
                return false;
            }

            await _jobInfoRepository.DeleteAsync(jobInfo);
            // If deletion was successful, return true
            return true;
        }

        public async Task<IEnumerable<GetJobInfoViewModelDtos>> GetAllJobInfosAsync()
        {
            var jobInfos = await _jobInfoRepository.GetJobInfosAsync();
            var jobInfoDtos = new List<GetJobInfoViewModelDtos>();

            foreach (var info in jobInfos)
            {
                var jobInfoDto = new GetJobInfoViewModelDtos(
                    info.JobInfo.Id,
                    info.JobInfo.JobTitle,
                    info.JobInfo.JobDescription,
                    info.JobInfo.MinimumSalary,
                    info.JobInfo.MaximumSalary,

                      info.JobInfo.TrainLine.TrainLineName,
                      info.JobInfo.Designation.DesignationName,
                      info.JobInfo.TrainLineId,
                      info.JobInfo.DesignationId,
                      info.SkillCount,
                      info.LocationCount,
                      info.ApplicationCount

                );
                jobInfoDtos.Add(jobInfoDto);
            }

            return jobInfoDtos;
        }


        public async Task<GetJobInfoViewModelDto> GetJobInfoByIdAsync(int id)
        {
            var jobInfo = await _jobInfoRepository.GetJobInfoByIdAsync(id);

            if (jobInfo == null)
            {
                // If the jobInfo with the given id doesn't exist, return null
                return null;
            }

            var jobInfoDto = new GetJobInfoViewModelDto(
                jobInfo.Id,
                jobInfo.JobTitle,
                jobInfo.JobDescription,
                jobInfo.MinimumSalary,
                jobInfo.MaximumSalary,
               
                jobInfo.TrainLine.TrainLineName,
                 jobInfo.Designation.DesignationName,
                jobInfo.TrainLineId,
                jobInfo.DesignationId

            );

            return jobInfoDto;
        }


        public async Task<GetJobInfoDto> UpdateJobInfoAsync(long id, UpdateJobInfoDto jobInfoDto)
        {
            var jobInfo = await _jobInfoRepository.GetByIdAsync(id);

            if (jobInfo == null)
            {
                // If the jobInfo with the given id doesn't exist, return null
                return null;
            }

            // Update the jobInfo entity with the data from the jobInfoDto
            jobInfo.JobTitle = jobInfoDto.JobTitle;
            jobInfo.JobDescription = jobInfoDto.JobDescription;
            jobInfo.MinimumSalary = jobInfoDto.MinimumSalary;
            jobInfo.MaximumSalary = jobInfoDto.MaximumSalary;
            jobInfo.TrainLineId = jobInfoDto.TrainLineId;
            jobInfo.DesignationId = jobInfoDto.DesignationId;

            await _jobInfoRepository.UpdateAsync(jobInfo);

            // Create a new GetJobInfoDTO object with the updated data and return it
            var updatedJobInfoDto = new GetJobInfoDto(
                jobInfo.Id,
                jobInfo.JobTitle,
                jobInfo.JobDescription,
                jobInfo.MinimumSalary,
                jobInfo.MaximumSalary,
                jobInfo.TrainLineId,
                jobInfo.DesignationId
            );

            return updatedJobInfoDto;
        }

    }
}
