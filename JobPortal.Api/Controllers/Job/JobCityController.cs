using JobPortal.DTO;
using JobPortal.DTO.Job;
using JobPortal.IServices.Job;
using JobPortal.Services.Job;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobPortal.Api.Controllers.Job
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCityController : ControllerBase
    {
        private IJobCityService _jobCityService;
        public JobCityController(IJobCityService jobCityService)
        {
            _jobCityService = jobCityService;
        }


        // GET: api/<JobCityController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJobCityDTO>>> Get()
        {
           var jobCitys =  await _jobCityService.GetAllJobCitiesAsync();

            return Ok(jobCitys);
        }

        // GET api/<JobCityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobCityDTO>> Get(int id)
        {
           var jobCity =  await _jobCityService.GetJobCityByIdAsync(id);

            return Ok(jobCity);
        }

        // POST api/<JobCityController>
        [HttpPost]
        public async Task<ActionResult<GetJobCityDTO>> Post([FromBody] IEnumerable<CreateJobCityDTO> jobCityDTOs)
        {
            var jobCitys = await _jobCityService.CreateJobCityAsync(jobCityDTOs);

            return Ok(jobCitys);

        }

        // PUT api/<JobCityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<JobCityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("JobCityByJobId/{JobId}")]
        public async Task<ActionResult<IEnumerable<GetJobCityViewModelDTO>>> GetJobCityByJobIdAsync(long jobId)
        {
            try
            {
                var jobCityDtos = await _jobCityService.GetJobCityByJobIdAsync(jobId);
                return Ok(jobCityDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Experience infos: {ex.Message}");
            }
        }
    }
}
