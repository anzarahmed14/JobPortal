using JobPortal.DTO;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ISkillService
    {
        Task<IEnumerable<GetSkillDTO>> SearchSkills(string query);
        Task<IEnumerable<GetSkillDTO>> GetSkillsAsync();
    }
}
