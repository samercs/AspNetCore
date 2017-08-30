using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Entity;
using AspNetCore.Entity.Enum;
using AspNetCore.Entity.Idintity;
using AspNetCore.Services;
using AspNetCore.Web.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Web.Controllers
{
    public class TestController : AppBaseController
    {
        private readonly UserService _userService;
        public TestController(IAppService appServices, UserManager<User> userManager, RoleManager<MyRole> roleManager) : base(appServices)
        {
            _userService = new UserService(DataContextFactory, userManager, roleManager);
        }
        public IActionResult Index()
        {
            var siteTitle = AppServices.AppSettings.SiteTitle;
            return View("Index", siteTitle);
        }

        public async Task<IActionResult> TestUserService()
        {
            var user = await _userService.GetUserById("2");
            user.Gender = Gender.Femail;
            await _userService.SaveUser(user);
            await _userService.SetRoles(user, new[] {"Administrator"});
            var roles = await _userService.GetRoles();
            var rolesNames = roles.Select(i => i.Name);
            var users = await _userService.GetUsers("", "Administrator");
            var result = $"Search user by Id : {user.UserName}, ";
            result += $"Role List: {string.Join(',', rolesNames)}, ";
            result += $"Users in Admin Role: {string.Join(',', users.Select(i => i.UserName))}";
            return Content(result);
        }

        
    }
}