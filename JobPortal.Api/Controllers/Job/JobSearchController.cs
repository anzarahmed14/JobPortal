using JobPortal.DTO.Job;
using JobPortal.IServices.Job;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers.Job
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSearchController : ControllerBase
    {
        private readonly IJobSearchService _jobSearchService;
        public JobSearchController(IJobSearchService jobSearchService) { 
            _jobSearchService = jobSearchService;
        }
        [HttpPost]
        public async Task<IActionResult> JobSearchAsync(JobSearch search)
        {
            var data  = await _jobSearchService.JobSearchAsync(search);
            return Ok(data);
        }

       
    }
}
