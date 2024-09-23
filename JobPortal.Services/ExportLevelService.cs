using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class ExportLevelService : IExportLevelService
    {
        private IExportLevelRepository _exportLevelRepository; 
        public ExportLevelService(IExportLevelRepository exportLevelRepository) {
            _exportLevelRepository = exportLevelRepository;
        }
        public async Task<IEnumerable<GetExportLevelsDTO>> GetExportLevelsAsync()
        {
           var exportLevel= await  _exportLevelRepository.GetAllAsync();

            var exportLevelsDTO = exportLevel.Select(e => (new GetExportLevelsDTO(e.Id,e.ExportLevelName)));

            return exportLevelsDTO;

        }
    }
}
