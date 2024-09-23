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
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<GetStateDTO> CreateStateAsync(CreateStateDTO stateDTO)
        {
            var stateEntity = MapToEntity(stateDTO);
            var createdStateEntity = await _stateRepository.CreateAsync(stateEntity);
            return MapToDTO(createdStateEntity);
        }

        public async Task<bool> DeleteStateAsync(long id)
        {
            var existingStateEntity = await _stateRepository.GetByIdAsync(id);
            if (existingStateEntity == null)
                return false;

            return await _stateRepository.DeleteAsync(existingStateEntity);
        }

        public async Task<IEnumerable<GetStateDTO>> GetAllStatesAsync()
        {
            var stateEntities = await _stateRepository.GetAllAsync();
            return stateEntities.Select(MapToDTO);
        }

        public async Task<GetStateDTO> GetStateByIdAsync(long id)
        {
            var stateEntity = await _stateRepository.GetByIdAsync(id);
            return stateEntity != null ? MapToDTO(stateEntity) : null;
        }

       

        public async Task<GetStateDTO> UpdateStateAsync(long id, UpdateStateDTO stateDTO)
        {
            var existingStateEntity = await _stateRepository.GetByIdAsync(id);
            if (existingStateEntity == null)
                return null;

            existingStateEntity.StateName = stateDTO.StateName;
            existingStateEntity.StateCode = stateDTO.StateCode;
            existingStateEntity.CountryId = stateDTO.CountryId;

            var updatedStateEntity = await _stateRepository.UpdateAsync(existingStateEntity);
            return MapToDTO(updatedStateEntity);
        }

        private GetStateDTO MapToDTO(State stateEntity)
        {
            return new GetStateDTO
            {
                Id = stateEntity.Id,
                StateName = stateEntity.StateName,
                StateCode = stateEntity.StateCode,
                CountryId = stateEntity.CountryId
            };
        }

        private State MapToEntity(CreateStateDTO stateDTO)
        {
            return new State
            {
                StateName = stateDTO.StateName,
                StateCode = stateDTO.StateCode,
                CountryId = stateDTO.CountryId
            };
        }

        private GetStateDTO MapToDTO(UpdateStateDTO stateDTO)
        {
            return new GetStateDTO
            {
                Id = stateDTO.Id,
                StateName = stateDTO.StateName,
                StateCode = stateDTO.StateCode,
                CountryId = stateDTO.CountryId
            };
        }
    }
}
