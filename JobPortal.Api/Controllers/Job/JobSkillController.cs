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
    public class JobSkillController : ControllerBase
    {
        private readonly IJobSkillService _jobSkillService;
        public JobSkillController(IJobSkillService jobSkillService)
        {
            _jobSkillService = jobSkillService;
        }


        // GET: api/<JobSkillController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJobSkillDTO>>> Get()
        {
           var jobSkills =  await _jobSkillService.GetAllJobSkillsAsync();

            return Ok(jobSkills);
        }

        // GET api/<JobSkillController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobSkillDTO>> Get(int id)
        {
           var jobSkill =  await _jobSkillService.GetJobSkillByIdAsync(id);

            return Ok(jobSkill);
        }

        // POST api/<JobSkillController>
        [HttpPost]
        public async Task<ActionResult<GetJobSkillDTO>> Post([FromBody] IEnumerable<CreateJobSkillDTO> jobSkillDTOs)
        {
            var jobSkills = await _jobSkillService.CreateJobSkillAsync(jobSkillDTOs);

            return Ok(jobSkills);

        }

        // PUT api/<JobSkillController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<JobSkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("JobSkillByJobId/{JobId}")]
        public async Task<ActionResult<IEnumerable<GetJobSkillViewModelDTO>>> GetJobSkillByJobIdAsync(long jobId)
        {
            try
            {
                var jobSkillDtos = await _jobSkillService.GetJobSkillByJobIdAsync(jobId);
                return Ok(jobSkillDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Experience infos: {ex.Message}");
            }
        }
    }
}
