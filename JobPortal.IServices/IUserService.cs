using JobPortal.DTO;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IUserService
    {
        Task<GetUserDTO> CreateUserAsync(CreateUserDTO user);
        Task<bool> DeleteUserAsync(long Id);
        Task<IEnumerable<GetUserDTO>> GetAllUsersAsync();
        Task<GetUserDTO> GetUserByIdAsync(long userId);
        Task<IEnumerable<GetUserDTO>> GetUsersByConditionAsync(Expression<Func<GetUserDTO, bool>> expression);
        Task<GetUserDTO> UpdateUserAsync(long Id, UpdateUserDTO user);
    }
}
