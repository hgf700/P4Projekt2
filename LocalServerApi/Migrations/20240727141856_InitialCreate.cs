using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoginData",
                columns: table => new
                {
                    IdLogin = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Granttype = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    UserLoginRegisterIdLoginRegister = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginData", x => x.IdLogin);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginRegister",
                columns: table => new
                {
                    IdLoginRegister = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdLogin = table.Column<int>(type: "integer", nullable: false),
                    IdRegister = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginRegister", x => x.IdLoginRegister);
                    table.ForeignKey(
                        name: "FK_UserLoginRegister_UserLoginData_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "UserLoginData",
                        principalColumn: "IdLogin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRegisterData",
                columns: table => new
                {
                    IdRegister = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Granttype = table.Column<string>(type: "text", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    UserLoginRegisterIdLoginRegister = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegisterData", x => x.IdRegister);
                    table.ForeignKey(
                        name: "FK_UserRegisterData_UserLoginRegister_UserLoginRegisterIdLogin~",
                        column: x => x.UserLoginRegisterIdLoginRegister,
                        principalTable: "UserLoginRegister",
                        principalColumn: "IdLoginRegister",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginData_UserLoginRegisterIdLoginRegister",
                table: "UserLoginData",
                column: "UserLoginRegisterIdLoginRegister");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginRegister_IdLogin",
                table: "UserLoginRegister",
                column: "IdLogin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginRegister_IdRegister",
                table: "UserLoginRegister",
                column: "IdRegister",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRegisterData_UserLoginRegisterIdLoginRegister",
                table: "UserRegisterData",
                column: "UserLoginRegisterIdLoginRegister");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginData_UserLoginRegister_UserLoginRegisterIdLoginReg~",
                table: "UserLoginData",
                column: "UserLoginRegisterIdLoginRegister",
                principalTable: "UserLoginRegister",
                principalColumn: "IdLoginRegister",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginRegister_UserRegisterData_IdRegister",
                table: "UserLoginRegister",
                column: "IdRegister",
                principalTable: "UserRegisterData",
                principalColumn: "IdRegister",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginData_UserLoginRegister_UserLoginRegisterIdLoginReg~",
                table: "UserLoginData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRegisterData_UserLoginRegister_UserLoginRegisterIdLogin~",
                table: "UserRegisterData");

            migrationBuilder.DropTable(
                name: "UserLoginRegister");

            migrationBuilder.DropTable(
                name: "UserLoginData");

            migrationBuilder.DropTable(
                name: "UserRegisterData");
        }
    }
}
