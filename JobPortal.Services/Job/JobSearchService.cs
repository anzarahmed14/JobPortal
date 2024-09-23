using JobPortal.DTO.Job;
using JobPortal.IRepositories;
using JobPortal.IRepositories.Job;
using JobPortal.IServices.Job;
using JobPortal.Model;
using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Job
{
    public class JobSearchService : IJobSearchService
    {
        private  readonly IJobSkillRepository _skillJobRepository  ;
        private readonly IJobCityRepository _cityJobRepository ;
        private readonly IJobInfoRepository _jobInfoRepository ;
        public JobSearchService(IJobCityRepository jobCityRepository, IJobSkillRepository skillRepository, IJobInfoRepository jobInfoRepository) {
            _cityJobRepository = jobCityRepository;
            _skillJobRepository = skillRepository;
            _jobInfoRepository = jobInfoRepository;
        }

        public async Task<IEnumerable<SearchJobResult>> JobSearchAsync(JobSearch search)
        {


            var cityIds = search.Cities.Select(city => city.Id).ToList();
            Expression<Func<JobCity, bool>> expression = jobCity => cityIds.Contains(jobCity.CityId);

            // Get all JobCity entries that match the city IDs
            var jobCityEntries = await _cityJobRepository.GetByConditionAsync(expression);

            // Now extract the related jobs
            var jobCityIds = jobCityEntries.Select(city => city.JobId).Distinct().ToList();

            /*For skill*/
            var skillIds = search.Skills.Select(skill => skill.Id).ToList();

            Expression<Func<JobSkill,bool>> skillExpression = jobSkill=> skillIds.Contains(jobSkill.SkillId);


            // Get all JobSkill entries that match the city IDs
            var jobSkillEntries = await _skillJobRepository.GetByConditionAsync(skillExpression);

            var jobSkillIds = jobSkillEntries.Select(skill => skill.JobId).Distinct().ToList();
            /*End For skill*/


            // Combine both lists and get unique job IDs
            var uniqueJobIds = jobCityIds.Union(jobSkillIds).Distinct().ToList();


            //Filter the record in job info
            Expression<Func<JobInfo, bool>> jobInfoExpression = jobs =>
            uniqueJobIds.Contains(jobs.Id) || jobs.DesignationId == search.DesignationId || jobs.TrainLineId == search.TrainLineId;


            // var tets =     await   _jobInfoRepository.GetByConditionAsync(jobInfoExpression);

            IEnumerable<JobInfo> JobInfos = await _jobInfoRepository.SearchJobInfoAsync(uniqueJobIds, search.DesignationId, search.TrainLineId);


                 IEnumerable <SearchJobResult> searchResults  =     
                JobInfos.Select(x=> new SearchJobResult(x.Id
                , x.JobTitle
                ,x.JobDescription
               
                , x.MinimumSalary
                ,x.MaximumSalary
                ,x.TrainLine?.TrainLineName ?? string.Empty
                ,x.Designation?.DesignationName?? string.Empty
                ,x.JobSkills.Select(js=>js.Skill?.SkillName?? string.Empty).ToList()
                ,x.JobCities.Select(js=>js.City?.CityName?? string.Empty).ToList()
                ,x.Company.CompanyName ?? string.Empty
                ,x.Company.EmailAddress ?? string.Empty
                ,x.Company.MobileNo ?? string.Empty

               ) ).ToList();

         
            return searchResults;
        }
    }
}
