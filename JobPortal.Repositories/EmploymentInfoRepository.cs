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
    public class EmploymentInfoRepository : Repository<EmploymentInfo>, IEmploymentInfoRepository
    {
        public EmploymentInfoRepository(JobPortalDbContext context) : base(context)
        {
        }
      
    }
}
