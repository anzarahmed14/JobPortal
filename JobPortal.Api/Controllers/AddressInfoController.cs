using JobPortal.DTO;
using JobPortal.IServices;
using JobPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressInfoController : ControllerBase
    {
        private readonly IAddressInfoService _addressInfoService;

        public AddressInfoController(IAddressInfoService addressInfoService)
        {
            _addressInfoService = addressInfoService;
        }

        // GET: api/AddressInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAddressInfoDTO>>> Get()
        {
            try
            {
                var addressInfos = await _addressInfoService.GetAllAddressInfosAsync();


                return Ok(addressInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving address infos: {ex.Message}");
            }
        }

        // GET: api/AddressInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAddressInfoDTO>> Get(long Id)
        {
            try
            {
                var addressInfo = await _addressInfoService.GetAddressInfoByIdAsync(Id);
                if (addressInfo == null)
                {
                    return NotFound();
                }
                return Ok(addressInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving address info: {ex.Message}");
            }
        }

        // POST: api/AddressInfo
        [HttpPost]
        public async Task<ActionResult<GetAddressInfoDTO>> Post([FromBody] CreateAddressInfoDTO addressInfoDTO)
        {
            try
            {
                var createdAddressInfo = await _addressInfoService.CreateAddressInfoAsync(addressInfoDTO);
                return Ok(createdAddressInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating address info: {ex.Message}");
            }
        }

        // PUT: api/AddressInfo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetAddressInfoDTO>> Put(long Id, [FromBody] UpdateAddressInfoDTO addressInfoDTO)
        {
            if (Id != addressInfoDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }

            try
            {
                var addressInfo = await _addressInfoService.UpdateAddressInfoAsync(Id, addressInfoDTO);
                return Ok(addressInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating address info: {ex.Message}");
            }
        }

        // DELETE: api/AddressInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _addressInfoService.DeleteAddressInfoAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting address info: {ex.Message}");
            }
        }
        // GET: api/AddressInfo/ByUserId/5
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<GetAcademicInfoDto>> GetAcademicInfosByUserIdAsync(long userId)
        {
            try
            {
                var academicInfoDTOs = await _addressInfoService.GetAddressInfosByUserIdAsync(userId);
                return Ok(academicInfoDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic infos: {ex.Message}");
            }
        }
        // GET: api/AddressInfo/ByUserId/5
        [HttpGet("DetailByUserId/{userId}")]
        public async Task<ActionResult<GetAcademicInfoDto>> GetAddressInfoDetailByUserIdAsync(long userId)
        {
            try
            {
                var academicInfoDTOs = await _addressInfoService.GetAddressInfoDetailByUserIdAsync(userId);
                return Ok(academicInfoDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving academic infos: {ex.Message}");
            }
        }
    }
}
