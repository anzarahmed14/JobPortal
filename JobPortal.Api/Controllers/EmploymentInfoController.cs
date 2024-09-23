using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentInfoController : ControllerBase
    {
        private readonly IEmploymentInfoService _employmentInfoService;
      

        public EmploymentInfoController(IEmploymentInfoService employmentInfoService)
        {
            _employmentInfoService = employmentInfoService;
           
        }

        // GET: api/EmploymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmploymentInfoDTO>>> Get()
        {
            try
            {
                var employmentDetails = await _employmentInfoService.GetAllEmploymentInfosAsync();
                return Ok(employmentDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving employment details: {ex.Message}");
            }
        }

        // GET: api/EmploymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmploymentInfoDTO>> Get(long id)
        {
            try
            {
                var employmentDetail = await _employmentInfoService.GetEmploymentInfoByIdAsync(id);
                if (employmentDetail == null)
                {
                    return NotFound();
                }
                return Ok(employmentDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving employment detail: {ex.Message}");
            }
        }

        // POST: api/EmploymentDetail
        [HttpPost]
        public async Task<ActionResult<GetEmploymentInfoDTO>> Post([FromBody] CreateEmploymentInfoDTO employmentDetailDTO)
        {
            try
            {
                var createdEmploymentDetail = await _employmentInfoService.CreateEmploymentInfoAsync(employmentDetailDTO);
               return Ok(createdEmploymentDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating employment detail: {ex.Message}");
            }
        }

        // PUT: api/EmploymentDetail/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetEmploymentInfoDTO>> Put(long id, [FromBody] UpdateEmploymentInfoDTO employmentDetailDTO)
        {
            if (id != employmentDetailDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var employmentDetail = await _employmentInfoService.UpdateEmploymentInfoAsync(id, employmentDetailDTO);
                return Ok(employmentDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating employment detail: {ex.Message}");
            }
        }

        // DELETE api/<EmploymentDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _employmentInfoService.DeleteEmploymentInfoAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting employment detail: {ex.Message}");
            }
        }

        // GET: api/EmploymentInfo/ByUserId/5
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<GetAcademicInfoDto>> GetAcademicInfosByUserIdAsync(long userId)
        {
            try
            {
                var academicInfoDTOs = await _employmentInfoService.GetEmploymentInfosByUserIdAsync(userId);
                return Ok(academicInfoDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic infos: {ex.Message}");
            }
        }

    }
}
