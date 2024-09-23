using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetUserDTO(long Id, string EmailAddress, string Password);
    public record UpdateUserDTO(long Id, string EmailAddress, string Password);
    public record CreateUserDTO(string EmailAddress, string Password);
    public record DeleteUserDTO(long Id);

    //public record UserLoginRequestDTO
    //{
    //    public string EmailAddress;
    //    public string Password;
    //}

     public record UserLoginRequestDTO(string EmailAddress, string Password);
    //public record UserLoginResponseDTO
    //{
    //    public long Id;
    //    public string EmailAddress;
    //}

    public record UserLoginResponseDTO(long Id,string EmailAddress, string Role);
}
