using JobPortal.DTO.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Job
{
    public interface IJobSearchService
    {
        public Task<IEnumerable<SearchJobResult>> JobSearchAsync(JobSearch search);
    }
}
