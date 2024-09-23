using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetExperienceInfoDTO(long Id, string CompanyName, DateTime StartDate, DateTime EndDate, long DesignationId, bool IsCurrentlyWorking , string Description, long UserId);


    public record GetExperienceInfosDTO(long Id, string CompanyName, DateTime StartDate, DateTime EndDate, long DesignationId, string DesignationName, bool IsCurrentlyWorking, string Description, long UserId);


    public record CreateExperienceInfoDTO( string CompanyName, DateTime StartDate, DateTime EndDate, long DesignationId, bool IsCurrentlyWorking, string Description, long UserId);
    public record UpdateExperienceInfoDTO(long Id, string CompanyName, DateTime StartDate, DateTime EndDate, long DesignationId, bool IsCurrentlyWorking, string Description, long UserId);



}
