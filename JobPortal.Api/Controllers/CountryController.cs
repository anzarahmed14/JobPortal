using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetAllCountries()
        {
            try
            {
                var countries = await _countryService.GetAllCountriesAsync();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving countries: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDTO>> GetCountryById(long id)
        {
            try
            {
                var country = await _countryService.GetCountryByIdAsync(id);
                if (country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving country: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetCountryDTO>> CreateCountry([FromBody] CreateCountryDTO createCountryDTO)
        {
            try
            {
                var createdCountry = await _countryService.CreateCountryAsync(createCountryDTO);
                return CreatedAtAction(nameof(GetCountryById), new { id = createdCountry.Id }, createdCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating country: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetCountryDTO>> UpdateCountry(long id, [FromBody] UpdateCountryDTO updateCountryDTO)
        {
            if (id != updateCountryDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var updatedCountry = await _countryService.UpdateCountryAsync(id, updateCountryDTO);
                if (updatedCountry == null)
                {
                    return NotFound();
                }
                return Ok(updatedCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating country: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCountry(long id)
        {
            try
            {
                var isDeleted = await _countryService.DeleteCountryAsync(id);
                if (!isDeleted)
                {
                    return NotFound();
                }
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting country: {ex.Message}");
            }
        }
    }
}
