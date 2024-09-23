using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Job
{
    //public record JobSearch (List<Skill>  Skills, List<City> Cities, int DesignationId, int ExperienceId, int TrainLineId);

    public record JobSearch(List<SkillDTO> Skills, List<CityDTO> Cities, int DesignationId, int ExperienceId, int TrainLineId);
}
