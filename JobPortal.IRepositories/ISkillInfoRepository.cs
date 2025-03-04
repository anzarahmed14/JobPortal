﻿using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories
{
    public interface ISkillInfoRepository : IRepository<SkillInfo>
    {
        Task<IReadOnlyCollection<SkillInfo>> GetSkillInfosByUserIdAsync(long userId);
    }
}
