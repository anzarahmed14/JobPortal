using JobPortal.DTO;
using JobPortal.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainLineController : ControllerBase
    {
        private readonly ITrainLineService _trainLineService;

        public TrainLineController(ITrainLineService trainLineService)
        {
            _trainLineService = trainLineService;
        }

        // GET: api/TrainLine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTrainLineDTO>>> GetTrainLines()
        {
            var trainLines = await _trainLineService.GetAllTrainLinesAsync();
            return Ok(trainLines);
        }

        // GET: api/TrainLine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTrainLineDTO>> GetTrainLine(long id)
        {
            var trainLine = await _trainLineService.GetTrainLineByIdAsync(id);

            if (trainLine == null)
            {
                return NotFound();
            }

            return trainLine;
        }

        // POST: api/TrainLine
        [HttpPost]
        public async Task<ActionResult<long>> CreateTrainLine(CreateTrainLineDTO createTrainLineDTO)
        {
            var id = await _trainLineService.AddTrainLineAsync(createTrainLineDTO);
            return CreatedAtAction(nameof(GetTrainLine), new { id }, id);
        }

        // PUT: api/TrainLine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainLine(long id, UpdateTrainLineDTO updateTrainLineDTO)
        {
            if (id != updateTrainLineDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _trainLineService.UpdateTrainLineAsync(updateTrainLineDTO);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // DELETE: api/TrainLine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainLine(long id)
        {
            try
            {
                await _trainLineService.DeleteTrainLineAsync(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
