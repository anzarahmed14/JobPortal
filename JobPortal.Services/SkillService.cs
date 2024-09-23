using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobPortal.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository  _skillRepository;
        public SkillService(ISkillRepository skillRepository) { 
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<GetSkillDTO>> GetSkillsAsync()
        {
            var skills = await _skillRepository.GetAllAsync();

            if (skills != null)
            {
                var skillsDTO = skills.Select(x => new GetSkillDTO(x.Id, x.SkillName));
                return skillsDTO;
            }
            else
            {
                return Enumerable.Empty<GetSkillDTO>(); // or any appropriate response if skills are null
            }
        }

        public async Task<IEnumerable<GetSkillDTO>> SearchSkills(string query)
        {
            var skills =  await _skillRepository.SearchSkills(query);

            if (skills != null)
            {
                var skillsDTO = skills.Select(x => new GetSkillDTO(x.Id, x.SkillName));
                return skillsDTO;
            }
            else
            {
                return Enumerable.Empty<GetSkillDTO>(); // or any appropriate response if skills are null
            }
        }

       
    }
}
