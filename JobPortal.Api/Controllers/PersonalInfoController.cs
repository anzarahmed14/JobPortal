using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfoService _personalInfoService;

        public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        // GET: api/PersonalInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPersonalInfoDTO>>> Get()
        {
            try
            {
                var personalInfos = await _personalInfoService.GetAllPersonalInfosAsync();
                return Ok(personalInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving personal infos: {ex.Message}");
            }
        }

        // GET: api/PersonalInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPersonalInfoDTO>> Get(long Id)
        {
            try
            {
                var personalInfo = await _personalInfoService.GetPersonalInfoByIdAsync(Id);
                if (personalInfo == null)
                {
                    return NotFound();
                }
                return Ok(personalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving personal info: {ex.Message}");
            }
        }
        // POST: api/PersonalInfo
        [HttpPost]
        public async Task<ActionResult<GetPersonalInfoDTO>> Post([FromBody] CreatePersonalInfoDTO personalInfoDTO)
        {
            try
            {
                var createdPersonalInfo = await _personalInfoService.CreatePersonalInfoAsync(personalInfoDTO);
              

                return Ok(createdPersonalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating personal info: {ex.Message}");
            }
        }

        // PUT: api/PersonalInfo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetPersonalInfoDTO>> Put(long Id, [FromBody] UpdatePersonalInfoDTO personalInfoDTO)
        {
            if (Id != personalInfoDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var personalInfo = await _personalInfoService.UpdatePersonalInfoAsync(Id,personalInfoDTO);

                return Ok(personalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating personal info: {ex.Message}");
            }
        }

        // DELETE api/<PersonalInfoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await _personalInfoService.DeletePersonalInfoAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while deleting personal info: {ex.Message}");
            }
        }

        // GET: api/PersonalInfo/ByUserId/5
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<GetAcademicInfoDto>> GetPersonalInfoByUserIdAsync(long userId)
        {
            try
            {
                var academicInfoDTOs = await _personalInfoService.GetPersonalInfoByUserIdAsync(userId);
                return Ok(academicInfoDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic infos: {ex.Message}");
            }
        }

    }
}
