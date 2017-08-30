using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Entity.Idintity
{
    public class MyRole : IdentityRole<int>
    {
        public MyRole() : base()
        {
        }

        public MyRole(string roleName)
        {
            Name = roleName;
        }
    }
}