using JobPortal.Data;
using JobPortal.IRepositories;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(JobPortalDbContext context) : base(context)
        {
        }

        public async Task< IEnumerable<Skill>> SearchSkills(string query)
        {
            return await _context.Skills
                .Where(s => s.SkillName.ToLower().Contains(query.ToLower()))
                .ToListAsync();
        }
    }
}
