using InstaSharp.Context;
using InstaSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InstaSharp.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<ApplicationUser> GetByUsername(string userName, InstaDbContext _ctx)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<ApplicationUser> GetByUsernameOrId(string userName, InstaDbContext _ctx)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.UserName == userName || u.Id == userName);
        }
    }

    public interface IUserRepository
    {
        Task<ApplicationUser> GetByUsername(string userName, InstaDbContext _ctx);
        Task<ApplicationUser> GetByUsernameOrId(string userName, InstaDbContext _ctx);
    }
}