using JobPortal.DTO.RequestDTO;
using JobPortal.Model;
using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories.Job
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        public Task<IEnumerable<JobApplication>> GetJobApplicationsAsync(JobApplicationRequestDto jobApplicationRequestDto);
    }
}
