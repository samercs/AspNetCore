using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AspNetCore.Data.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var roleName = "Administrator";
            migrationBuilder.Sql("insert into dbo.AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp) values ('" + Guid.NewGuid().ToString().ToLower() + "', '"+roleName+"', '"+roleName.ToUpper()+"', '"+ Guid.NewGuid().ToString() + "');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from dbo.AspNetUserRoles");
            migrationBuilder.Sql("delete from dbo.AspNetRoles");
        }
    }
}
