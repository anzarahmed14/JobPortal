using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories
{
    public interface IExperienceInfoRepository : IRepository<ExperienceInfo>
    {
        public Task<ExperienceInfo> GetExperienceInfoByIdAsync(long id);
      public Task<IReadOnlyCollection<ExperienceInfo>> GetExperienceInfoByUserIdAsync(long userId);
    }
}
