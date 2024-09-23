using JobPortal.Data;
using JobPortal.IRepositories;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(JobPortalDbContext context) : base(context)
        {
        }
        public async Task<User> UserLoginAsync(string EmailAddress, string Password)
        {
            return await _context.Users
                .Include(x => x.Role)
                .Where(u => u.EmailAddress == EmailAddress && u.Password == Password)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
