using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebsite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Users",
               columns: table => new
               {
                   ID = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   FullName = table.Column<string>(nullable: true),
                   Email = table.Column<string>(nullable: true),
                   Position = table.Column<string>(nullable: true),
                   DateJoined = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_User", x => x.ID);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                            name: "Users");
        }
    }
}
