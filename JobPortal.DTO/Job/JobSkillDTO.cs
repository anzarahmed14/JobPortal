using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Job
{
    public record GetJobSkillDTO(long Id
        
        , long SkillId
        , long JobId
        );

    public record GetJobSkillViewModelDTO(long Id

      , long SkillId
       ,string SkillName
      , long JobId
      );

    public record CreateJobSkillDTO(long Id
        , long SkillId
        , long JobId
       );

    public record UpdateJobSkillDTO(long Id
        , long SkillId
        , long JobId
      );
}
