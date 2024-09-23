using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetCompanyDTO(long Id,string CompanyName, string EmailAddress, string MobileNo);
    public record CreateCompanyDTO(long Id, string CompanyName, string EmailAddress, string MobileNo, long UserId);
    public record UpdateCompanyDTO(long Id, string CompanyName, string EmailAddress, string MobileNo, long UserId);

    //
}
