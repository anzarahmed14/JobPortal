using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class TrainLineService : ITrainLineService
    {
        private readonly ITrainLineRepository _trainLineRepository;

        public TrainLineService(ITrainLineRepository trainLineRepository)
        {
            _trainLineRepository = trainLineRepository;
        }

        public async Task<List<GetTrainLineDTO>> GetAllTrainLinesAsync()
        {
            var trainLines = await _trainLineRepository.GetAllAsync();
            var dtos = new List<GetTrainLineDTO>();
            foreach (var trainLine in trainLines)
            {
                dtos.Add(new GetTrainLineDTO
                {
                    Id = trainLine.Id,
                    TrainLineName = trainLine.TrainLineName
                });
            }
            return dtos;
        }

        public async Task<GetTrainLineDTO> GetTrainLineByIdAsync(long id)
        {
            var trainLine = await _trainLineRepository.GetByIdAsync(id);
            if (trainLine == null)
                return null;

            return new GetTrainLineDTO
            {
                Id = trainLine.Id,
                TrainLineName = trainLine.TrainLineName
            };
        }

        public async Task<long> AddTrainLineAsync(CreateTrainLineDTO createTrainLineDTO)
        {
            var trainLine = new TrainLine
            {
                TrainLineName = createTrainLineDTO.TrainLineName
            };
            await _trainLineRepository.CreateAsync(trainLine);
            return trainLine.Id;
        }

        public async Task UpdateTrainLineAsync(UpdateTrainLineDTO updateTrainLineDTO)
        {
            var trainLine = await _trainLineRepository.GetByIdAsync(updateTrainLineDTO.Id);
            if (trainLine == null)
            {
                throw new ArgumentException($"Train line with ID {updateTrainLineDTO.Id} not found.");
            }

            trainLine.TrainLineName = updateTrainLineDTO.TrainLineName;

            await _trainLineRepository.UpdateAsync(trainLine);
        }

        public async Task DeleteTrainLineAsync(long id)
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
