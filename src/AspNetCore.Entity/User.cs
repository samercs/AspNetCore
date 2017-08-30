using System;
using AspNetCore.Entity.Enum;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Entity
{
    public class User: IdentityUser<int>
    {
        public Gender Gender { get; set; }
    }
}
