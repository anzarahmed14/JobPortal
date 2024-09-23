using JobPortal.DTO;
using JobPortal.DTO.Job;
using JobPortal.DTO.RequestDTO;
using JobPortal.IServices.Job;
using JobPortal.Services.Job;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Controllers.Job
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        public JobApplicationController(IJobApplicationService jobApplicationService) { 
            _jobApplicationService = jobApplicationService;
        }
        // POST: api/JobApplication
        [HttpPost]
        public async Task<ActionResult<GetJobApplicationDto>> Post([FromBody] CreateJobApplicationDto jobApplicationDto)
        {
            try
            {
                var createdJobApplicationDto = await _jobApplicationService.CreateJobApplicationAsync(jobApplicationDto);
                return Ok(createdJobApplicationDto);
            }
            catch (DbUpdateException dbEx)
            {
                // Check if it's a unique constraint violation
                if (dbEx.InnerException is SqlException sqlEx && sqlEx.Message.Contains("IX_JobApplications_UserId_JobId"))
                {
                    return Conflict("The user has already applied for this job.");
                }
                // Other DB related exceptions can be handled here
                return StatusCode(500, $"A database error occurred: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating job application info: {ex.Message}");
            }
        }

        // GET: api/<JobCityController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJobApplicationViewDto>>> Get([FromQuery] JobApplicationRequestDto jobApplicationRequestDto)
        {
            var jobApplications = await _jobApplicationService.GetJobApplicationsAsync(jobApplicationRequestDto);

            return Ok(jobApplications);
        }
    }
}
