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
    public class EmploymentInfoService : IEmploymentInfoService
    {
        private readonly IEmploymentInfoRepository _employmentInfoRepository; 
        public EmploymentInfoService(IEmploymentInfoRepository employmentInfoRepository)
        {
            _employmentInfoRepository = employmentInfoRepository;
        }

        public async Task<GetEmploymentInfoDTO> CreateEmploymentInfoAsync(CreateEmploymentInfoDTO employmentDetailDto)
        {
            try
            {
                var employmentInfo = new EmploymentInfo()
                {
                    UpdatedUserId = employmentDetailDto.UserId,
                    CreatedUserId = employmentDetailDto.UserId,
                    CurrentCTC = employmentDetailDto.CurrentCTC,
                    NoticePeriodId = employmentDetailDto.NoticePeriodId,
                    ExpectedCTC = employmentDetailDto.ExpectedCTC,
                    UserId = employmentDetailDto.UserId,
                  

                };

                var newEmploymentInfo = await _employmentInfoRepository.CreateAsync(employmentInfo);


                var newEmploymentInfoDTO = new GetEmploymentInfoDTO(
                    newEmploymentInfo.Id,
                   newEmploymentInfo.CurrentCTC,
                   newEmploymentInfo.NoticePeriodId,
                    newEmploymentInfo.ExpectedCTC,
                    newEmploymentInfo.UserId);

                return newEmploymentInfoDTO;
            }
            catch (Exception)
            {

                throw;
            }


            
        }

        public async Task<bool> DeleteEmploymentInfoAsync(long id)
        {
            try
            {
                var employmentInfo = await _employmentInfoRepository.GetByIdAsync(id);

                if (employmentInfo == null)
                {
                    throw new Exception($"Then employment Info with Id {id} not found for delete");
                }

                return await _employmentInfoRepository.DeleteAsync(employmentInfo);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<GetEmploymentInfoDTO>> GetAllEmploymentInfosAsync()
        {
            try
            {
                var employmentInfos = await _employmentInfoRepository.GetAllAsync();

                var employmentInfosDto = employmentInfos.Select(info => (new GetEmploymentInfoDTO(
                            info.Id,
                            info.CurrentCTC,
                            info.NoticePeriodId,
                            info.ExpectedCTC,
                            info.UserId)));

                return employmentInfosDto;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<GetEmploymentInfoDTO> GetEmploymentInfoByIdAsync(long Id)
        {

            try
            {
                var employmentInfo = await _employmentInfoRepository.GetByIdAsync(Id);

                var employmentInfoDto = new GetEmploymentInfoDTO(
                                employmentInfo.Id,
                            employmentInfo.CurrentCTC,
                            employmentInfo.NoticePeriodId,
                            employmentInfo.ExpectedCTC,
                            employmentInfo.UserId);

                return employmentInfoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetEmploymentInfoDTO> GetEmploymentInfosByUserIdAsync(long userId)
        {
            try
            {
                // Retrieve employment info by user ID
                var employmentInfo = await _employmentInfoRepository.GetSingleOrDefaultAsync(a => a.UserId == userId);

                // If employment info is found, map it to DTO and return
                if (employmentInfo != null)
                {
                    return MapEmploymentInfoToDTO(employmentInfo);
                }
                else
                {
                    return null; // No employment info found for the given user ID
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it gracefully
                throw; // Rethrow the exception for now
            }
        }
        /*
        private GetEmploymentInfoDTO MapEmploymentInfoToDTO(EmploymentInfo employmentInfo)
        {
            return new GetEmploymentInfoDTO
            {
                Id = employmentInfo.Id,
                CurrentCTC = employmentInfo.CurrentCTC,
                NoticePeriodId = employmentInfo.NoticePeriodId,
                ExpectedCTC = employmentInfo.ExpectedCTC,
                UserId = employmentInfo.UserId
            };
        }*/
        private GetEmploymentInfoDTO MapEmploymentInfoToDTO(EmploymentInfo employmentInfo)
        {
            return new GetEmploymentInfoDTO(
                employmentInfo.Id,
                employmentInfo.CurrentCTC,
                employmentInfo.NoticePeriodId,
                employmentInfo.ExpectedCTC,
                employmentInfo.UserId
            );
        }


        public async Task<GetEmploymentInfoDTO> UpdateEmploymentInfoAsync(long Id, UpdateEmploymentInfoDTO employmentDetailDTO)
        {
            try
            {
                var employmentInfo = await _employmentInfoRepository.GetByIdAsync(Id);
                if (employmentInfo == null)
                {  // Throw custom exception indicating user not found
                    throw new Exception($"Employment info with ID {Id} not found for update.");
                }


                employmentInfo.UpdatedUserId = employmentDetailDTO.UserId;
                employmentInfo.CurrentCTC = employmentDetailDTO.CurrentCTC;
                employmentInfo.NoticePeriodId = employmentDetailDTO.NoticePeriodId;
               employmentInfo. ExpectedCTC = employmentDetailDTO.ExpectedCTC;
                employmentInfo.UserId = employmentDetailDTO.UserId;
                employmentInfo.UpdatedUserId = employmentDetailDTO.UserId;
                employmentInfo.UpdatedDate = DateTime.Now;


                var updatedEmploymentInfo = await _employmentInfoRepository.UpdateAsync(employmentInfo);

                var employmentInfoDto = new GetEmploymentInfoDTO(
                                  updatedEmploymentInfo.Id,
                              updatedEmploymentInfo.CurrentCTC,
                              updatedEmploymentInfo.NoticePeriodId,
                              updatedEmploymentInfo.ExpectedCTC,
                              updatedEmploymentInfo.UserId);
                return employmentInfoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
