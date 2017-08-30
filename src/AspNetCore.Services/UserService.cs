using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Data;
using AspNetCore.Entity;
using AspNetCore.Entity.Idintity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IReadOnlyCollection<User>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>>  GetUsers(string search, string role)
        {
            using (var dc = DataContext())
            {
                var users = ((IdentityDbContext<User, MyRole, int>)dc).Users.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    users = users.Where(i =>
                        i.UserName.Contains(search) ||
                        i.Email.Contains(search));
                }

                
                if (!string.IsNullOrEmpty(role))
                {
                    var result = new List<User>();
                    var identityRole = _roleManager.Roles.SingleOrDefault(i => i.Name == role);
                    if (identityRole == null)
                    {
                        throw new ArgumentException("Cannot find role '" + role + "'.");
                    }

                    var usersEntity = users.ToList();
                    foreach (var user in usersEntity)
                    {
                        var userRole = await _userManager.GetRolesAsync(user);
                        if (userRole.Contains(role))
                        {
                            result.Add(user);
                        }
                    }
                    return result;
                }

                return await users.ToListAsync();
            }
        }

        public async Task<User> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _userManager.FindByEmailAsync(userName);
        }

        public async Task<IReadOnlyCollection<MyRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IReadOnlyCollection<string>> GetRolesForUser(User user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task AddRole(User user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task SetRoles(User user, IEnumerable<string> roles)
        {
            var allRoles = await _roleManager.Roles.ToListAsync();
            var unassignedRoles = allRoles.Where(i => !roles.Contains(i.Name)).Select(i => i.Name);

            foreach (var unassignedRole in unassignedRoles)
            {
                await _userManager.RemoveFromRoleAsync(user, unassignedRole);
            }

            foreach (var role in roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            // TODO: This doesn't seem to work
            //await _userManager.RemoveFromRolesAsync(user, unassignedRoles);
            //await _userManager.AddToRolesAsync(user, roles);
        }

        public async Task SaveUser(User user)
        {
            await _userManager.UpdateAsync(user);
        }
    }
}