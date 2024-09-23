using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticePeriodController : ControllerBase
    {
        private readonly INoticePeriodService _trainLineService;

        public NoticePeriodController(INoticePeriodService trainLineService)
        {
            _trainLineService = trainLineService;
        }

        // GET: api/NoticePeriod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetNoticePeriodDTO>>> GetNoticePeriods()
        {
            var trainLines = await _trainLineService.GetAllNoticePeriodsAsync();
            return Ok(trainLines);
        }

        // GET: api/NoticePeriod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetNoticePeriodDTO>> GetNoticePeriod(long id)
        {
            var trainLine = await _trainLineService.GetNoticePeriodByIdAsync(id);

            if (trainLine == null)
            {
                return NotFound();
            }

            return trainLine;
        }

        // POST: api/NoticePeriod
        [HttpPost]
        public async Task<ActionResult<long>> CreateNoticePeriod(CreateNoticePeriodDTO createNoticePeriodDTO)
        {
            var id = await _trainLineService.AddNoticePeriodAsync(createNoticePeriodDTO);
            return CreatedAtAction(nameof(GetNoticePeriod), new { id }, id);
        }

        // PUT: api/NoticePeriod/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNoticePeriod(long id, UpdateNoticePeriodDTO updateNoticePeriodDTO)
        {
            if (id != updateNoticePeriodDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _trainLineService.UpdateNoticePeriodAsync(updateNoticePeriodDTO);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // DELETE: api/NoticePeriod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoticePeriod(long id)
        {
            try
            {
                await _trainLineService.DeleteNoticePeriodAsync(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
