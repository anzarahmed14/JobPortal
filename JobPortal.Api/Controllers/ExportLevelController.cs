using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportLevelController : ControllerBase
    {
        private IExportLevelService _exportLevelService;

        public ExportLevelController(IExportLevelService  exportLevelService)
        {
            _exportLevelService = exportLevelService;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetExportLevelsDTO>>> Get()
        {
            try
            {
                var  exportLevelsDTOs = await _exportLevelService.GetExportLevelsAsync();
                return Ok(exportLevelsDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving cities: {ex.Message}");
            }
        }
    }
}
