using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetAcademicInfoDto(long Id, string InstitutionName, int StartYear, int EndYear, double Percentage, string Degree, long UserId);





    public record CreateAcademicInfoDto(string InstitutionName, int StartYear, int EndYear, double Percentage, string Degree, long UserId);
    public record UpdateAcademicInfoDto(long Id, string InstitutionName, int StartYear, int EndYear, double Percentage, string Degree, long UserId);
}
