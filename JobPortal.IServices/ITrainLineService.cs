using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories
{
    public interface ITrainLineService
    {
        Task<List<GetTrainLineDTO>> GetAllTrainLinesAsync();
        Task<GetTrainLineDTO> GetTrainLineByIdAsync(long id);
        Task<long> AddTrainLineAsync(CreateTrainLineDTO createTrainLineDTO);
        Task UpdateTrainLineAsync(UpdateTrainLineDTO updateTrainLineDTO);
        Task DeleteTrainLineAsync(long id);
    }
}
