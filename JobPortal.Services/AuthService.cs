using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserLoginResponseDTO> AuthenticateAsync(string userName, string password)
        {

            try
            {
                Expression<Func<User, bool>> expression = a => a.EmailAddress == userName && a.Password == password;

                var userInfo = await _userRepository.UserLoginAsync(userName, password);
                    if(userInfo !=null)
                {
                    var userInfoDto = new UserLoginResponseDTO(userInfo.Id, userInfo.EmailAddress, userInfo.Role.RoleCode);

                    return userInfoDto;
                }
                else
                {
                    return null;
                }

            
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
