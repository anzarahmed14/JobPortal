using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using JobPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetSkillDTO>> SearchSkills(string query)
        {
            return await _skillService.SearchSkills(query);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSkillDTO>>> Get()
        {
            
            try
            {
                var skillsDto = await _skillService.GetSkillsAsync();
                return Ok(skillsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving skill infos: {ex.Message}");
            }
        }
    }
}
