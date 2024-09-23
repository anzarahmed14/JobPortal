using JobPortal.DTO.Job;
using JobPortal.IServices.Job;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers.Job
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobInfoController : ControllerBase
    {
        private readonly IJobInfoService _jobInfoService;

        public JobInfoController(IJobInfoService jobInfoService)
        {
            _jobInfoService = jobInfoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobInfoViewModelDto>> GetJobInfoByIdAsync(int id)
        {
            var jobInfoDto = await _jobInfoService.GetJobInfoByIdAsync(id);
            if (jobInfoDto == null)
            {
                return NotFound();
            }
            return Ok(jobInfoDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJobInfoViewModelDto>>> GetAllJobInfosAsync()
        {
            var jobInfoDtos = await _jobInfoService.GetAllJobInfosAsync();
            return Ok(jobInfoDtos);
        }

        [HttpPost]
        public async Task<ActionResult<GetJobInfoDto>> CreateJobInfoAsync(CreateJobInfoDto jobInfoDto)
        {
          var createdJobInfo =   await _jobInfoService.CreateJobInfoAsync(jobInfoDto);
           
            return Ok(createdJobInfo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetJobInfoDto>> UpdateJobInfoAsync(long id, UpdateJobInfoDto jobInfoDto)
        {
            var updatedJobInfoDto = await _jobInfoService.UpdateJobInfoAsync(id, jobInfoDto);
            if (updatedJobInfoDto == null)
            {
                return NotFound();
            }
            return Ok(updatedJobInfoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobInfoAsync(long id)
        {
            var result = await _jobInfoService.DeleteJobInfoAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
