using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COREAPP2.Persistence.DbContexts.Migrations
{
    public partial class Ef_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_COMMON_CODE",
                columns: table => new
                {
                    CODE_TYPE = table.Column<string>(maxLength: 32, nullable: false),
                    CODE_ID = table.Column<string>(maxLength: 32, nullable: false),
                    CODE_TYPE_NAME = table.Column<string>(maxLength: 128, nullable: false),
                    CODE_NAME = table.Column<string>(maxLength: 128, nullable: false),
                    CODE_VAL = table.Column<int>(nullable: true),
                    SORT_ORDER = table.Column<int>(nullable: true),
                    USE_YN = table.Column<bool>(nullable: true),
                    CODE_COMMENT = table.Column<string>(maxLength: 128, nullable: true),
                    CREATE_USER_ID = table.Column<string>(maxLength: 16, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_COMMON_CODE", x => new { x.CODE_TYPE, x.CODE_ID });
                    table.UniqueConstraint("AK_T_COMMON_CODE_CODE_ID_CODE_TYPE", x => new { x.CODE_ID, x.CODE_TYPE });
                });

            migrationBuilder.CreateTable(
                name: "T_MENU_MASTER",
                columns: table => new
                {
                    MENU_IDENTITY = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MENU_ID = table.Column<string>(maxLength: 64, nullable: true),
                    MENU_NAME = table.Column<string>(maxLength: 64, nullable: true),
                    PARENT_MENUID = table.Column<string>(maxLength: 64, nullable: true),
                    USER_ROLL = table.Column<string>(maxLength: 450, nullable: true),
                    USER_AUTH = table.Column<int>(nullable: true),
                    USER_DUTY = table.Column<int>(nullable: true),
                    MENU_AREA = table.Column<string>(maxLength: 64, nullable: true),
                    MENU_CONTROLLER = table.Column<string>(maxLength: 64, nullable: true),
                    MENU_ACTION = table.Column<string>(maxLength: 64, nullable: true),
                    USE_YN = table.Column<bool>(nullable: true),
                    SORT_ORDER = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CSS_CLASS = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MENU_MASTER", x => x.MENU_IDENTITY);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_COMMON_CODE");

            migrationBuilder.DropTable(
                name: "T_MENU_MASTER");
        }
    }
}
