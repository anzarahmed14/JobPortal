using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IAuthService
    {
        public Task<UserLoginResponseDTO> AuthenticateAsync(string username, string password);
    }
}
