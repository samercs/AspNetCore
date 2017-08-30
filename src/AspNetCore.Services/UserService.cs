using System;
using System.Threading.Tasks;
using AspNetCore.Data;
using AspNetCore.Entity;
using AspNetCore.Entity.Idintity;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Services
{
    public class UserService: ServiceBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<MyRole> _roleManager;
        public UserService(IDataContextFactory dataContextFactory, UserManager<User> userManager, RoleManager<MyRole> roleManager) : base(dataContextFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            user.CreatedUtc = DateTime.Now;
            user.IsDeleted = false;
            return await _userManager.CreateAsync(user, password);
        }
    }
}