using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthorizationServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRegisterData",
                columns: table => new
                {
                    IdRegister = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ResponseType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Firstname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ClientId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Scope = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RedirectUri = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CodeChallenge = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CodeChallengeMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegisterData", x => x.IdRegister);
                    table.UniqueConstraint("AK_UserRegisterData_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GuidId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorizationKey = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Expire = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserRegisterEmail = table.Column<string>(type: "character varying(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keys_UserRegisterData_UserRegisterEmail",
                        column: x => x.UserRegisterEmail,
                        principalTable: "UserRegisterData",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    UserEmail = table.Column<string>(type: "character varying(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_UserRegisterData_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "UserRegisterData",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginData",
                columns: table => new
                {
                    IdLogin = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResponseType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ClientId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserRegisterEmail = table.Column<string>(type: "character varying(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginData", x => x.IdLogin);
                    table.ForeignKey(
                        name: "FK_UserLoginData_UserRegisterData_UserRegisterEmail",
                        column: x => x.UserRegisterEmail,
                        principalTable: "UserRegisterData",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keys_UserRegisterEmail",
                table: "Keys",
                column: "UserRegisterEmail");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserEmail",
                table: "RefreshTokens",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginData_UserRegisterEmail",
                table: "UserLoginData",
                column: "UserRegisterEmail");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegisterData_Email",
                table: "UserRegisterData",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserLoginData");

            migrationBuilder.DropTable(
                name: "UserRegisterData");
        }
    }
}
