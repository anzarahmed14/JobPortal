using JobPortal.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Job
{
    public record GetJobInfoDto(long Id
        ,string JobTitle
        ,string JobDescription
        ,int MinimumSalary
        ,int MaximumSalary
        ,long TrainLineId
        ,long DesignationId
        );

    public record CreateJobInfoDto(long Id
       , string JobTitle
       , string JobDescription
       , int MinimumSalary
       , int MaximumSalary
       , long TrainLineId
       , long DesignationId
       , long UserId
       );

    public record UpdateJobInfoDto(long Id
      , string JobTitle
      , string JobDescription
      , int MinimumSalary
      , int MaximumSalary
      , long TrainLineId
      , long DesignationId
      );

    public record GetJobInfoViewModelDtos(long Id
       , string JobTitle
       , string JobDescription
       , int MinimumSalary
       , int MaximumSalary
       , string TrainLineName
       , string DesignationName
       , long TrainLineId
       , long DesignationId
        ,int SkillCount
        ,int LocationCount
        ,int ApplicationCount
       );

    public record GetJobInfoViewModelDto(long Id
   , string JobTitle
   , string JobDescription
   , int MinimumSalary
   , int MaximumSalary
   , string TrainLineName
   , string DesignationName
   , long TrainLineId
   , long DesignationId
   
   );

    public record GetJobInfos (JobInfo JobInfo, int SkillCount, int LocationCount, int ApplicationCount);


    public record SearchJobResult(long Id
   , string JobTitle
   , string JobDescription
   , int MinimumSalary
   , int MaximumSalary
   , string TrainLineName
   , string DesignationName
   ,List<string> skills, List<string> cities
   ,string CompanyName, string CompanyEmailAddress, string CompanyMobileNo
    );

}
