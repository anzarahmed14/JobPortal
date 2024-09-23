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
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(JobPortalDbContext context) : base(context)
        {
        }
    }
}
