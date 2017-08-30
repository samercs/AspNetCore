using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AspNetCore.Data.Migrations
{
    public partial class SeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var role = "Administrator";
            migrationBuilder.Sql(
                $"insert into dbo.AspNetRoles (ConcurrencyStamp, Name, NormalizedName) values (LOWER(NEWID()), '{role}', '{role.ToUpper()}');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from dbo.AspNetRoles");
        }
    }
}
