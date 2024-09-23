using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
       Task<User> UserLoginAsync(string EmailAddress, string Password);
    }
}
