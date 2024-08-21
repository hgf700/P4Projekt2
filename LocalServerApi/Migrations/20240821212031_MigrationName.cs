using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityService.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserKey");

            migrationBuilder.AddColumn<int>(
                name: "UserRegisterDataId",
                table: "Keys",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                    UserRegisterDataId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginData", x => x.IdLogin);
                    table.ForeignKey(
                        name: "FK_UserLoginData_UserRegisterData_UserRegisterDataId",
                        column: x => x.UserRegisterDataId,
                        principalTable: "UserRegisterData",
                        principalColumn: "IdRegister",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keys_UserRegisterDataId",
                table: "Keys",
                column: "UserRegisterDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginData_UserRegisterDataId",
                table: "UserLoginData",
                column: "UserRegisterDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keys_UserRegisterData_UserRegisterDataId",
                table: "Keys",
                column: "UserRegisterDataId",
                principalTable: "UserRegisterData",
                principalColumn: "IdRegister",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keys_UserRegisterData_UserRegisterDataId",
                table: "Keys");

            migrationBuilder.DropTable(
                name: "UserLoginData");

            migrationBuilder.DropIndex(
                name: "IX_Keys_UserRegisterDataId",
                table: "Keys");

            migrationBuilder.DropColumn(
                name: "UserRegisterDataId",
                table: "Keys");

            migrationBuilder.CreateTable(
                name: "UserKey",
                columns: table => new
                {
                    KeyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKey", x => new { x.KeyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserKey_Keys_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Keys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserKey_UserRegisterData_UserId",
                        column: x => x.UserId,
                        principalTable: "UserRegisterData",
                        principalColumn: "IdRegister",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserKey_UserId",
                table: "UserKey",
                column: "UserId");
        }
    }
}
