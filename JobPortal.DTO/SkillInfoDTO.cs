using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetSkillInfoDTO(long Id, long SkillId, long ExpertLevelId);
    public record CreateSkillInfoDTO(long SkillId, long ExpertLevelId, long UserId);

    public record UpdateSkillInfoDTO(long Id,long SkillId, long ExpertLevelId, long UserId);

    public record GetSkillInfoDTOs(long Id, long SkillId, long ExpertLevelId, string ExpertLevelName, string SkillName);
}
