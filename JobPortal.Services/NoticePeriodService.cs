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
    public class NoticePeriodService : INoticePeriodService
    {
        private readonly INoticePeriodRepository _trainLineRepository;

        public NoticePeriodService(INoticePeriodRepository trainLineRepository)
        {
            _trainLineRepository = trainLineRepository;
        }

        public async Task<List<GetNoticePeriodDTO>> GetAllNoticePeriodsAsync()
        {
            var trainLines = await _trainLineRepository.GetAllAsync();
            var dtos = new List<GetNoticePeriodDTO>();
            foreach (var trainLine in trainLines)
            {
                dtos.Add(new GetNoticePeriodDTO
                {
                    Id = trainLine.Id,
                    NoticePeriodName = trainLine.NoticePeriodName
                });
            }
            return dtos;
        }

        public async Task<GetNoticePeriodDTO> GetNoticePeriodByIdAsync(long id)
        {
            var trainLine = await _trainLineRepository.GetByIdAsync(id);
            if (trainLine == null)
                return null;

            return new GetNoticePeriodDTO
            {
                Id = trainLine.Id,
                NoticePeriodName = trainLine.NoticePeriodName
            };
        }

        public async Task<long> AddNoticePeriodAsync(CreateNoticePeriodDTO createNoticePeriodDTO)
        {
            var trainLine = new NoticePeriod
            {
                NoticePeriodName = createNoticePeriodDTO.NoticePeriodName
            };
            await _trainLineRepository.CreateAsync(trainLine);
            return trainLine.Id;
        }

        public async Task UpdateNoticePeriodAsync(UpdateNoticePeriodDTO updateNoticePeriodDTO)
        {
            var trainLine = await _trainLineRepository.GetByIdAsync(updateNoticePeriodDTO.Id);
            if (trainLine == null)
            {
                throw new ArgumentException($"Train line with ID {updateNoticePeriodDTO.Id} not found.");
            }

            trainLine.NoticePeriodName = updateNoticePeriodDTO.NoticePeriodName;

            await _trainLineRepository.UpdateAsync(trainLine);
        }

        public async Task DeleteNoticePeriodAsync(long id)
        {
            var trainLine = await _trainLineRepository.GetByIdAsync(id);
            if (trainLine == null)
            {
                throw new ArgumentException($"Train line with ID {id} not found.");
            }

            await _trainLineRepository.DeleteAsync(trainLine);
        }
    }
}
