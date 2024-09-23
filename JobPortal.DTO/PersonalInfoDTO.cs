using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    //public class PersonalInfoDTO
    //{
    //}


    /*
       public record GetPersonalInfoDTOWithAll(long Id, string FirstName, string LastName = "", string MobileNumber = "", string PhoneNumber = "", string Description = "", bool IsActive = false, long UserId = 0);
    public record GetPersonalInfoDTO(long Id, string FirstName, string LastName = "", string MobileNumber ="", string PhoneNumber ="" , string Description = "", bool IsActive = false, long UserId = 0);
     */

    public record GetPersonalInfoDTO(long Id,string FirstName, string LastName, string EmailAddress, string MobileNumber, string PhoneNumber, string Description, bool IsActive, long UserId);
    public record CreatePersonalInfoDTO([Required(ErrorMessage = "First name is required")] string FirstName, string LastName, string MobileNumber, string PhoneNumber, string Description, bool IsActive, long UserId);
    public record UpdatePersonalInfoDTO(long Id, string FirstName, string LastName, string EmailAddress, string MobileNumber, string PhoneNumber, string Description, bool IsActive, long UserId);
    //public record DeletePersonalInfoDTO(long Id);
}
