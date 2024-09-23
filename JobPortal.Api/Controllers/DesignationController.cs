using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _cityService;

        public DesignationController(IDesignationService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDesignationDTO>>> Get()
        {
            try
            {
                var cities = await _cityService.GetAllCitiesAsync();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving cities: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDesignationDTO>> Get(long id)
        {
            try
            {
                var city = await _cityService.GetDesignationByIdAsync(id);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the city: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetDesignationDTO>> Post([FromBody] CreateDesignationDTO cityDTO)
        {
            try
            {
                var createdDesignation = await _cityService.CreateDesignationAsync(cityDTO);
                return CreatedAtAction(nameof(Get), new { id = createdDesignation.Id }, createdDesignation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the city: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetDesignationDTO>> Put(long id, [FromBody] UpdateDesignationDTO cityDTO)
        {
            if (id != cityDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var updatedDesignation = await _cityService.UpdateDesignationAsync(id, cityDTO);
                return Ok(updatedDesignation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the city: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _cityService.DeleteDesignationAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the city: {ex.Message}");
            }
        }
    }
}
