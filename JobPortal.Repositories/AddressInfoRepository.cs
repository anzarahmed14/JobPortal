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
    public class AddressInfoRepository : Repository<AddressInfo>, IAddressInfoRepository
    {
        public AddressInfoRepository(JobPortalDbContext context) : base(context)
        {
        }
        public async Task<AddressInfo> GetAddressInfoDetailByUserIdAsync(long UserId)
        {
            var query = _context.AddressInfos.AsNoTracking().Include(c=>c.City).Include(t=>t.TrainLine)
                .Include(s=>s.State).Include(c=>c.Country).AsQueryable();

            if (UserId > 0)
            {
                query = query.Where(a => a.UserId == UserId);
            }
            var addressInfoDetail = await query.FirstOrDefaultAsync();

            return addressInfoDetail;
        }
    }
}
