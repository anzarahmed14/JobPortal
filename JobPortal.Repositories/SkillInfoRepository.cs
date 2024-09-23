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

    public class SkillInfoRepository : Repository<SkillInfo>, ISkillInfoRepository
    {
        public SkillInfoRepository(JobPortalDbContext context) : base(context)
        {
        }
        public async Task<IReadOnlyCollection<SkillInfo>> GetSkillInfosByUserIdAsync(long userId)
        {
            return await _context.SkillInfos
                        .Include(x => x.Skill).Include(x=>x.ExportLevel).Where(x => x.UserId == userId).ToListAsync();

        }
    }
}
