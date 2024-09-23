using JobPortal.Data;
using JobPortal.IRepositories;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        public DesignationRepository(JobPortalDbContext context) : base(context)
        {
        }
    }
}
