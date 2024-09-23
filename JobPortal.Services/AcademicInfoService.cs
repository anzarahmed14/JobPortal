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
    public class AcademicInfoService : IAcademicInfoService
    {
        private readonly IAcademicInfoRepository _academicInfoRepository;

        public AcademicInfoService(IAcademicInfoRepository academicInfoRepository)
        {
            _academicInfoRepository = academicInfoRepository;
        }

        public async Task<GetAcademicInfoDto> CreateAcademicInfoAsync(CreateAcademicInfoDto academicInfoDTO)
        {
            try
            {
                var academicInfo = new AcademicInfo()
                {
                    InstitutionName = academicInfoDTO.InstitutionName,
                    StartYear = academicInfoDTO.StartYear,
                    EndYear = academicInfoDTO.EndYear,
                    Percentage = academicInfoDTO.Percentage,
                    Degree = academicInfoDTO.Degree,
                    UserId = academicInfoDTO.UserId,
                    CreatedUserId = academicInfoDTO.UserId
                   
                };


                var newAcademicInfo = await _academicInfoRepository.CreateAsync(academicInfo);

                var newAcademicInfoDTO = new GetAcademicInfoDto(
                    newAcademicInfo.Id,
                    newAcademicInfo.InstitutionName,
                    newAcademicInfo.StartYear,
                    newAcademicInfo.EndYear,
                    newAcademicInfo.Percentage,
                    newAcademicInfo.Degree,
                    newAcademicInfo.UserId);

                return newAcademicInfoDTO;
            }
            catch (Exception)
            {

                throw;
            }
                
        }

        public async Task<bool> DeleteAcademicInfoAsync(long Id)
        {
            try
            {
                var academicInfo = await _academicInfoRepository.GetByIdAsync(Id);
                if (academicInfo == null)
                {
                    throw new Exception($"Academic Info ID {Id} not found for Delete");

                }

                return await _academicInfoRepository.DeleteAsync(academicInfo);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<GetAcademicInfoDto> GetAcademicInfoByIdAsync(long Id)
        {
            try
            {
                var academicInfo = await _academicInfoRepository.GetByIdAsync(Id);

                var academicInfoDTO = new GetAcademicInfoDto(
                      academicInfo.Id,
                      academicInfo.InstitutionName,
                      academicInfo.StartYear,
                      academicInfo.EndYear,
                      academicInfo.Percentage,
                      academicInfo.Degree,
                      academicInfo.UserId);

                return academicInfoDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetAcademicInfoDto>> GetAllAcademicInfosAsync()
        {
            try
            {
                var academicInfos = await _academicInfoRepository.GetAllAsync();

                var academicInfosDto = academicInfos.Select(academic => new GetAcademicInfoDto(academic.Id,
                          academic.InstitutionName,
                          academic.StartYear,
                          academic.EndYear,
                          academic.Percentage,
                          academic.Degree,
                          academic.UserId));

                return academicInfosDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetAcademicInfoDto> UpdateAcademicInfoAsync(long Id, UpdateAcademicInfoDto academicInfoDTO)
        {
            try
            {
                var academicInfo = await _academicInfoRepository.GetByIdAsync(Id);
                if (academicInfo == null)
                {
                    throw new Exception($"Academic Info ID {Id} not found for Delete");

                }

                academicInfo.InstitutionName = academicInfoDTO.InstitutionName;
                academicInfo.StartYear = academicInfoDTO.StartYear;
                academicInfo.EndYear = academicInfoDTO.EndYear;
                academicInfo.Percentage = academicInfoDTO.Percentage;
                academicInfo.Degree = academicInfoDTO.Degree;
                academicInfo.UserId = academicInfoDTO.UserId;
                academicInfo.UpdatedUserId = academicInfoDTO.UserId;
                academicInfo.UpdatedDate = DateTime.Now;

                var updatedAcademicInfo = await _academicInfoRepository.UpdateAsync(academicInfo);

                var updatedAcademicInfoDto = new GetAcademicInfoDto(
                        updatedAcademicInfo.Id,
                        updatedAcademicInfo.InstitutionName,
                        updatedAcademicInfo.StartYear,
                        updatedAcademicInfo.EndYear,
                        updatedAcademicInfo.Percentage,
                        updatedAcademicInfo.Degree,
                        updatedAcademicInfo.UserId);

                return updatedAcademicInfoDto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetAcademicInfoDto>> GetAcademicInfosByUserIdAsync(long userId)
        {
            try
            {
                // Define the expression to filter academic infos by userId
                Expression<Func<AcademicInfo, bool>> expression = a => a.UserId == userId;

                // Call the repository method to get academic infos based on the expression
                var academicInfos = await _academicInfoRepository.GetByConditionAsync(expression);

                // Convert academic infos to DTOs
                var academicInfoDTOs = academicInfos.Select(a => new GetAcademicInfoDto(a.Id, a.InstitutionName, a.StartYear, a.EndYear, a.Percentage, a.Degree, a.UserId));


                return academicInfoDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
