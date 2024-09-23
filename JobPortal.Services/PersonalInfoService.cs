using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;

        public PersonalInfoService(IPersonalInfoRepository personalInfoRepository) {
            _personalInfoRepository = personalInfoRepository;
        
        }

        public async Task<GetPersonalInfoDTO> CreatePersonalInfoAsync(CreatePersonalInfoDTO personalInfoDTO)
        {
            try
            {
                var personalInfo = new PersonalInfo()
                {
                    FirstName = personalInfoDTO.FirstName,
                    LastName = personalInfoDTO.LastName,
                    MobileNumber = personalInfoDTO.MobileNumber,
                    PhoneNumber = personalInfoDTO.PhoneNumber,
                    Description = personalInfoDTO.Description,
                    IsActive = personalInfoDTO.IsActive,
                    UserId = personalInfoDTO.UserId,
                    CreatedUserId = personalInfoDTO.UserId


                };

                var newPersonalInfo = await _personalInfoRepository.CreateAsync(personalInfo);

                var newPersonalInfoDTO = new GetPersonalInfoDTO(
                        newPersonalInfo.Id,
                        newPersonalInfo.FirstName,
                        newPersonalInfo.LastName,
                        newPersonalInfo.EmailAddress,
                        newPersonalInfo.MobileNumber,
                        newPersonalInfo.PhoneNumber,
                        newPersonalInfo.Description,
                        newPersonalInfo.IsActive,
                        newPersonalInfo.UserId
                    );

                return newPersonalInfoDTO;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeletePersonalInfoAsync(long id)
        {
            try
            {

                var personalInfo = await _personalInfoRepository.GetByIdAsync(id);
                if (personalInfo == null)
                {  // Throw custom exception indicating user not found
                    throw new Exception($"Personal info with ID {id} not found for delete.");
                }

                return await _personalInfoRepository.DeleteAsync(personalInfo);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<GetPersonalInfoDTO>> GetAllPersonalInfosAsync()
        {
            try
            {
                var personalInfos = await _personalInfoRepository.GetAllAsync();

                var personalInfosDto = personalInfos.Select(info => (new GetPersonalInfoDTO(
                            info.Id,
                            info.FirstName,
                            info.LastName,
                            info.EmailAddress,
                            info.MobileNumber,
                            info.PhoneNumber,
                            info.Description,
                            info.IsActive,
                            info.UserId)));

                return personalInfosDto;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<GetPersonalInfoDTO> GetPersonalInfoByIdAsync(long id)
        {
            try
            {
                var personalInfo = await _personalInfoRepository.GetByIdAsync(id);

                var personalInfoDto = new GetPersonalInfoDTO(personalInfo.Id,
                                personalInfo.FirstName,
                                personalInfo.LastName,
                                personalInfo.EmailAddress,
                                personalInfo.MobileNumber,
                                personalInfo.PhoneNumber,
                                personalInfo.Description,
                                personalInfo.IsActive,
                                personalInfo.UserId);

                return personalInfoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetPersonalInfoDTO> GetPersonalInfoByUserIdAsync(long userId)
        {
            try
            {//personalInfo
                // Define the expression to filter academic infos by userId
                Expression<Func<PersonalInfo, bool>> expression = a => a.UserId == userId;

                // Call the repository method to get academic infos based on the expression
                var personalInfos = await _personalInfoRepository.GetByConditionAsync(expression);

                // Convert academic infos to DTOs
                var personalInfoDTOs = personalInfos.Select(info => new GetPersonalInfoDTO(info.Id,
                            info.FirstName,
                            info.LastName,
                            info.EmailAddress,
                            info.MobileNumber,
                            info.PhoneNumber,
                            info.Description,
                            info.IsActive,
                            info.UserId)).FirstOrDefault();


                return personalInfoDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetPersonalInfoDTO> UpdatePersonalInfoAsync(long Id, UpdatePersonalInfoDTO personalInfoDTO)
        {
            try
            {
                var personalInfo = await _personalInfoRepository.GetByIdAsync(Id);
                if (personalInfo == null)
                {  // Throw custom exception indicating user not found
                    throw new Exception($"Personal info with ID {Id} not found for update.");
                }


                personalInfo.Id = personalInfoDTO.Id;
                personalInfo.FirstName = personalInfoDTO.FirstName;
                personalInfo.LastName = personalInfoDTO.LastName;
                personalInfo.EmailAddress = personalInfoDTO.EmailAddress;
                personalInfo.MobileNumber = personalInfoDTO.MobileNumber;
                personalInfo.PhoneNumber = personalInfoDTO.PhoneNumber;
                personalInfo.Description = personalInfoDTO.Description;
                personalInfo.IsActive = personalInfoDTO.IsActive;
                personalInfo.UserId = personalInfoDTO.UserId;
                personalInfo.UpdatedUserId = personalInfoDTO.UserId;
                personalInfo.UpdatedDate = DateTime.Now;


                var updatedPersonalInfo = await _personalInfoRepository.UpdateAsync(personalInfo);

                var updatedPersonalInfoDto = new GetPersonalInfoDTO(
                            updatedPersonalInfo.Id,
                            updatedPersonalInfo.FirstName,
                            updatedPersonalInfo.LastName,
                            updatedPersonalInfo.EmailAddress,
                            updatedPersonalInfo.MobileNumber,
                            updatedPersonalInfo.PhoneNumber,
                            updatedPersonalInfo.Description,
                            updatedPersonalInfo.IsActive,
                            updatedPersonalInfo.UserId
                        );
                return updatedPersonalInfoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
