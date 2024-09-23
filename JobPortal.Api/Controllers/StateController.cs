using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStateDTO>>> GetAllStates()
        {
            try
            {
                var states = await _stateService.GetAllStatesAsync();
                return Ok(states);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving states: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStateDTO>> GetStateById(long id)
        {
            try
            {
                var state = await _stateService.GetStateByIdAsync(id);
                if (state == null)
                {
                    return NotFound();
                }
                return Ok(state);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving state: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetStateDTO>> CreateState([FromBody] CreateStateDTO createStateDTO)
        {
            try
            {
                var createdState = await _stateService.CreateStateAsync(createStateDTO);
                return CreatedAtAction(nameof(GetStateById), new { id = createdState.Id }, createdState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating state: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetStateDTO>> UpdateState(long id, [FromBody] UpdateStateDTO updateStateDTO)
        {
            if (id != updateStateDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var updatedState = await _stateService.UpdateStateAsync(id, updateStateDTO);
                if (updatedState == null)
                {
                    return NotFound();
                }
                return Ok(updatedState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating state: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteState(long id)
        {
            try
            {
                var isDeleted = await _stateService.DeleteStateAsync(id);
                if (!isDeleted)
                {
                    return NotFound();
                }
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting state: {ex.Message}");
            }
        }
    }
}
