using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCityDTO>>> Get()
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
        public async Task<ActionResult<GetCityDTO>> Get(long id)
        {
            try
            {
                var city = await _cityService.GetCityByIdAsync(id);
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
        public async Task<ActionResult<GetCityDTO>> Post([FromBody] CreateCityDTO cityDTO)
        {
            try
            {
                var createdCity = await _cityService.CreateCityAsync(cityDTO);
                return CreatedAtAction(nameof(Get), new { id = createdCity.Id }, createdCity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the city: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetCityDTO>> Put(long id, [FromBody] UpdateCityDTO cityDTO)
        {
            if (id != cityDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var updatedCity = await _cityService.UpdateCityAsync(id, cityDTO);
                return Ok(updatedCity);
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
                var isDeleted = await _cityService.DeleteCityAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the city: {ex.Message}");
            }
        }
    }
}
