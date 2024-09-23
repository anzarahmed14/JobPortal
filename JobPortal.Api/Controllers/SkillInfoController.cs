using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillInfoController : ControllerBase
    {
        private readonly ISkillInfoService _SkillInfoService;

        public SkillInfoController(ISkillInfoService SkillInfoService)
        {
            _SkillInfoService = SkillInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSkillInfoDTO>>> Get()
        {
            try
            {
                var cities = await _SkillInfoService.GetAllSkillInfosAsync();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving cities: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetSkillInfoDTO>> Get(long id)
        {
            try
            {
                var SkillInfo = await _SkillInfoService.GetSkillInfoByIdAsync(id);
                if (SkillInfo == null)
                {
                    return NotFound();
                }
                return Ok(SkillInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the SkillInfo: {ex.Message}");
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<GetSkillInfoDTO>> Post([FromBody] CreateSkillInfoDTO skillInfoDTO)
        {
            try
            {
                var createdSkillInfo = await _SkillInfoService.CreateSkillInfoAsync(skillInfoDTO);
                return Ok(createdSkillInfo);
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;

                if (innerException is SqlException sqlException && sqlException.Number == 2601)
                {
                    // Handle unique constraint violation
                    return Conflict("Duplicate SkillId and UserId combination found.");
                }

                return StatusCode(500, $"An error occurred while creating the SkillInfo: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the SkillInfo: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetSkillInfoDTO>> Put(long id, [FromBody] UpdateSkillInfoDTO SkillInfoDTO)
        {
            if (id != SkillInfoDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var updatedSkillInfo = await _SkillInfoService.UpdateSkillInfoAsync(id, SkillInfoDTO);
                return Ok(updatedSkillInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the SkillInfo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _SkillInfoService.DeleteSkillInfoAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the SkillInfo: {ex.Message}");
            }
        }
        // GET: api/EmploymentInfo/ByUserId/5
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<GetSkillInfoDTOs>> GetSkillInfosByUserIdAsync(long userId)
        {
            try
            {
                var academicInfoDTOs = await _SkillInfoService.GetSkillInfosByUserIdAsync(userId);
                return Ok(academicInfoDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic infos: {ex.Message}");
            }
        }
    }
}
