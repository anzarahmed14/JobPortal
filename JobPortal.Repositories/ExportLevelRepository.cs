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
    public class ExportLevelRepository : Repository<ExportLevel>, IExportLevelRepository
    {
        public ExportLevelRepository(JobPortalDbContext context) : base(context)
        {
        }
    }
}
