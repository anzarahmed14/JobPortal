using JobPortal.Data;
using JobPortal.DTO;
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
    public class ExperienceInfoRepository : Repository<ExperienceInfo>, IExperienceInfoRepository
    {
        public ExperienceInfoRepository(JobPortalDbContext context) : base(context)
        {
        }
        public async Task<ExperienceInfo> GetExperienceInfoByIdAsync(long id)
        {
            return await _context.Experiences
                        .Include(x => x.Designation)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IReadOnlyCollection<ExperienceInfo>> GetExperienceInfoByUserIdAsync(long userId)
        {
            return await _context.Experiences
                        .Include(x => x.Designation).Where(x => x.UserId == userId).ToListAsync();
                        
        }

    }
}
