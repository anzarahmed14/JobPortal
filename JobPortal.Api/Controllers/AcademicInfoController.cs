using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicInfoController : ControllerBase
    {
        private readonly IAcademicInfoService _academicInfoService;

        public AcademicInfoController(IAcademicInfoService academicInfoService)
        {
            _academicInfoService = academicInfoService;
        }

        // GET: api/AcademicInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAcademicInfoDto>>> Get()
        {
            try
            {
                var academicInfos = await _academicInfoService.GetAllAcademicInfosAsync();
                return Ok(academicInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic infos: {ex.Message}");
            }
        }

        // GET: api/AcademicInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAcademicInfoDto>> Get(long id)
        {
            try
            {
                var academicInfo = await _academicInfoService.GetAcademicInfoByIdAsync(id);
                if (academicInfo == null)
                {
                    return NotFound();
                }
                return Ok(academicInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic info: {ex.Message}");
            }
        }

        // POST: api/AcademicInfo
        [HttpPost]
        public async Task<ActionResult<GetAcademicInfoDto>> Post([FromBody] CreateAcademicInfoDto academicInfoDTO)
        {
            try
            {
                var createdAcademicInfo = await _academicInfoService.CreateAcademicInfoAsync(academicInfoDTO);
                return Ok(createdAcademicInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating academic info: {ex.Message}");
            }
        }

        // PUT: api/AcademicInfo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetAcademicInfoDto>> Put(long Id, [FromBody] UpdateAcademicInfoDto academicInfoDTO)
        {
            if (Id != academicInfoDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
             
            }

            try
            {
                var academicInfo = await _academicInfoService.UpdateAcademicInfoAsync(Id,academicInfoDTO);
                return Ok(academicInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating academic info: {ex.Message}");
            }
        }

        // DELETE api/AcademicInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _academicInfoService.DeleteAcademicInfoAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting academic info: {ex.Message}");
            }
        }

        // GET: api/AcademicInfo/ByUserId/5
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<GetAcademicInfoDto>>> GetAcademicInfosByUserIdAsync(long userId)
        {
            try
            {
                var academicInfoDTOs = await _academicInfoService.GetAcademicInfosByUserIdAsync(userId);
                return Ok(academicInfoDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic infos: {ex.Message}");
            }
        }
    }
}
