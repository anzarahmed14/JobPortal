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
    public class AddressInfoService: IAddressInfoService
    {
        private readonly IAddressInfoRepository   _addressInfoRepository;

        public AddressInfoService(IAddressInfoRepository addressInfoRepository)
        {
            _addressInfoRepository = addressInfoRepository;
        }

        public async Task<GetAddressInfoDTO> CreateAddressInfoAsync(CreateAddressInfoDTO addressInfoDTO)
        {
            try
            {
                var addressInfo = new AddressInfo
                {
                    Address = addressInfoDTO.Address,
                    CityId = addressInfoDTO.CityId,
                    StateId = addressInfoDTO.StateId,
                    CountryId = addressInfoDTO.CountryId,
                    UserId = addressInfoDTO.UserId,
                    PostalCode = addressInfoDTO.PostalCode,
                    TrainLineId = addressInfoDTO.TrainLineId,
                    
                };

                var newAddressInfo = await _addressInfoRepository.CreateAsync(addressInfo);

                return MapToGetAddressInfoDTO(newAddressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating address info: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAddressInfoAsync(long Id)
        {
            try
            {
                var addressInfo = await _addressInfoRepository.GetByIdAsync(Id);
                if (addressInfo == null)
                {
                    throw new Exception($"Address info with ID {Id} not found for delete.");
                }

                return await _addressInfoRepository.DeleteAsync(addressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting address info: {ex.Message}");
            }
        }

        public async Task<IEnumerable<GetAddressInfoDTO>> GetAllAddressInfosAsync()
        {
            try
            {
                var addressInfos = await _addressInfoRepository.GetAllAsync();

                return addressInfos.Select(MapToGetAddressInfoDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving address infos: {ex.Message}");
            }
        }

        public async Task<GetAddressInfoDTO> GetAddressInfoByIdAsync(long Id)
        {
            try
            {
                var addressInfo = await _addressInfoRepository.GetByIdAsync(Id);
                if (addressInfo == null)
                {
                    return null;
                }

                return MapToGetAddressInfoDTO(addressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving address info: {ex.Message}");
            }
        }

        public async Task<GetAddressInfoDTO> UpdateAddressInfoAsync(long Id, UpdateAddressInfoDTO addressInfoDTO)
        {
            try
            {
                var addressInfo = await _addressInfoRepository.GetByIdAsync(Id);
                if (addressInfo == null)
                {
                    throw new Exception($"Address info with ID {Id} not found for update.");
                }

                addressInfo.Address = addressInfoDTO.Address;
                addressInfo.CityId = addressInfoDTO.CityId;
                addressInfo.StateId = addressInfoDTO.StateId;
                addressInfo.CountryId = addressInfoDTO.CountryId;
                addressInfo.UserId = addressInfoDTO.UserId;

                var updatedAddressInfo = await _addressInfoRepository.UpdateAsync(addressInfo);

                return MapToGetAddressInfoDTO(updatedAddressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating address info: {ex.Message}");
            }
        }
        public async Task<GetAddressInfoDTO> GetAddressInfosByUserIdAsync(long userId)
        {
            try
            {
                // Define the expression to filter academic infos by userId
                Expression<Func<AddressInfo, bool>> expression = a => a.UserId == userId;

                // Call the repository method to get academic infos based on the expression
                var addressInfos = await _addressInfoRepository.GetSingleOrDefaultAsync(expression);
                if (addressInfos != null)
                {
                    return MapToGetAddressInfoDTO(addressInfos);
                  

                }
                else
                {
                    return null; 
                }

               
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<GetAddressInfoDetailDto> GetAddressInfoDetailByUserIdAsync(long userId)
        {
            try
            {
                // Call the repository method to get academic infos based on the expression
                var addressInfos = await _addressInfoRepository.GetAddressInfoDetailByUserIdAsync(userId);
                if (addressInfos != null)
                {
                    return MapToGetAddressInfoDetailDTO(addressInfos);


                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        private GetAddressInfoDTO MapToGetAddressInfoDTO(AddressInfo addressInfo)
        {
            return new GetAddressInfoDTO
            {
                Id = addressInfo.Id,
                Address = addressInfo.Address,
                CityId = addressInfo.CityId,
                StateId = addressInfo.StateId,
                CountryId = addressInfo.CountryId,
                UserId = addressInfo.UserId,
                PostalCode = addressInfo.PostalCode,
                TrainLineId = addressInfo.TrainLineId
                
            };
        }
        private GetAddressInfoDetailDto MapToGetAddressInfoDetailDTO(AddressInfo addressInfo)
        {
            return new GetAddressInfoDetailDto
            {
                Id = addressInfo.Id,
                Address = addressInfo.Address,
                CityName = addressInfo.City.CityName,
                StateName = addressInfo.State.StateName,
                CountryName = addressInfo.Country.CountryName,
                UserId = addressInfo.UserId,
                PostalCode = addressInfo.PostalCode,
                TrainLineName = addressInfo.TrainLine.TrainLineName

            };
        }


    }
}
