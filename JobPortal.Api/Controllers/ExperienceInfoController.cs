using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceInfoController : ControllerBase
    {
        private readonly IExperienceInfoService _experienceInfoService;

        public ExperienceInfoController(IExperienceInfoService experienceInfoService)
        {
            _experienceInfoService = experienceInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetExperienceInfoDTO>>> Get()
        {
            try
            {
                var experiences = await _experienceInfoService.GetAllExperienceInfosAsync();
                return Ok(experiences);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving experiences: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetExperienceInfoDTO>> Get(long id)
        {
            try
            {
                var experience = await _experienceInfoService.GetExperienceInfoByIdAsync(id);
                if (experience == null)
                {
                    return NotFound();
                }
                return Ok(experience);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving experience: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetExperienceInfoDTO>> Post([FromBody] CreateExperienceInfoDTO experienceDTO)
        {
            try
            {
                var createdExperience = await _experienceInfoService.CreateExperienceInfoAsync(experienceDTO);
                return Ok(createdExperience);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating experience: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetExperienceInfoDTO>> Put(long id, [FromBody] UpdateExperienceInfoDTO experienceDTO)
        {
            try
            {
                var updatedExperience = await _experienceInfoService.UpdateExperienceInfoAsync(id, experienceDTO);
                return Ok(updatedExperience);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating experience: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _experienceInfoService.DeleteExperienceInfoAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting experience: {ex.Message}");
            }
        }

        // GET: api/AcademicInfo/ByUserId/5
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<GetExperienceInfosDTO>>> GetExperienceInfosByUserIdAsync(long userId)
        {
            try
            {
                var experienceInfoDTOs = await _experienceInfoService.GetExperienceInfosByUserIdAsync(userId);
                return Ok(experienceInfoDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Experience infos: {ex.Message}");
            }
        }

    }
}
