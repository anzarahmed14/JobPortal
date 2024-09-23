using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetEmploymentInfoDTO(long Id, double CurrentCTC, long NoticePeriodId, double ExpectedCTC, long UserId);
    public record CreateEmploymentInfoDTO(double CurrentCTC, long NoticePeriodId, double ExpectedCTC, long UserId);
    public record UpdateEmploymentInfoDTO(long Id, double CurrentCTC, long NoticePeriodId, double ExpectedCTC, long UserId);
}
