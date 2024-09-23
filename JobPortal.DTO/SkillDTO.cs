using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetSkillDTO(long Id, string SkillName);

    public record SkillDTO (long Id, string SkillName);
}
