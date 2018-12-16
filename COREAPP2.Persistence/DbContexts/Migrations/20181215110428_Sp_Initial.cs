using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COREAPP2.Persistence.DbContexts.Migrations
{
    public partial class Sp_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_COMP_INFO",
                columns: table => new
                {
                    COMP_SEQ = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMP_NAME = table.Column<string>(nullable: true),
                    COMP_DESCRIPTION = table.Column<string>(nullable: true),
                    COMP_REF = table.Column<string>(nullable: true),
                    STANDARD_YEAR = table.Column<string>(nullable: true),
                    DIAG_TYPE = table.Column<string>(nullable: true),
                    CONFIRM_YN = table.Column<bool>(nullable: true),
                    USE_YN = table.Column<bool>(nullable: true),
                    CREATE_USER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(nullable: true),
                    UPDATE_USER_ID = table.Column<string>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(nullable: true),
                    COMP_DETAIL_GUBUN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_COMP_INFO", x => x.COMP_SEQ);
                });

            migrationBuilder.CreateTable(
                name: "T_VULN_GROUP",
                columns: table => new
                {
                    GROUP_SEQ = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UPPER_SEQ = table.Column<long>(nullable: false),
                    LEVEL = table.Column<int>(nullable: false),
                    GROUP_TYPE = table.Column<string>(nullable: true),
                    COMP_SEQ = table.Column<long>(nullable: false),
                    DIAG_KIND = table.Column<string>(nullable: true),
                    DIAG_TERM = table.Column<string>(nullable: true),
                    GROUP_ID = table.Column<string>(nullable: true),
                    GROUP_NAME = table.Column<string>(nullable: true),
                    DIAG_TOOL = table.Column<string>(nullable: true),
                    SORT_ORDER = table.Column<int>(nullable: true),
                    CREATE_USER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(nullable: true),
                    UPDATE_USER_ID = table.Column<string>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VULN_GROUP", x => x.GROUP_SEQ);
                    table.ForeignKey(
                        name: "FK_T_VULN_GROUP_T_COMP_INFO_COMP_SEQ",
                        column: x => x.COMP_SEQ,
                        principalTable: "T_COMP_INFO",
                        principalColumn: "COMP_SEQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_VULN",
                columns: table => new
                {
                    VULN_SEQ = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GROUP_SEQ = table.Column<long>(nullable: false),
                    MANUAL_YN = table.Column<bool>(nullable: true),
                    AUTO_YN = table.Column<bool>(nullable: true),
                    MANAGE_ID = table.Column<string>(nullable: true),
                    CLIENT_STANDARD_ID = table.Column<string>(nullable: true),
                    VULN_NAME = table.Column<string>(nullable: true),
                    SORT_ORDER = table.Column<int>(nullable: true),
                    RULE_YN = table.Column<bool>(nullable: true),
                    RATE = table.Column<int>(nullable: true),
                    SCORE = table.Column<int>(nullable: true),
                    APPLY_TIME = table.Column<string>(nullable: true),
                    DETAIL = table.Column<string>(nullable: true),
                    DETAIL_PATH = table.Column<string>(nullable: true),
                    JUDGEMENT = table.Column<string>(nullable: true),
                    EFFECT = table.Column<string>(nullable: true),
                    REMEDY = table.Column<string>(nullable: true),
                    REMEDY_PATH = table.Column<string>(nullable: true),
                    REFRRENCE = table.Column<string>(nullable: true),
                    PARSER_CONTENTS = table.Column<string>(nullable: true),
                    ORG_PARSER_CONTENTS = table.Column<string>(nullable: true),
                    APPLY_TARGET = table.Column<string>(nullable: true),
                    USE_YN = table.Column<bool>(nullable: true),
                    EXCEPT_CD = table.Column<string>(nullable: true),
                    EXCEPT_TERM_TYPE = table.Column<string>(nullable: true),
                    EXCEPT_TERM_FR = table.Column<DateTime>(nullable: true),
                    EXCEPT_TERM_TO = table.Column<DateTime>(nullable: true),
                    EXCEPT_REASON = table.Column<string>(nullable: true),
                    EXCEPT_USER_ID = table.Column<string>(nullable: true),
                    EXCEPT_DT = table.Column<DateTime>(nullable: true),
                    CREATE_USER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(nullable: true),
                    UPDATE_USER_ID = table.Column<string>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(nullable: true),
                    VULGROUP = table.Column<long>(nullable: true),
                    VULNO = table.Column<string>(nullable: true),
                    REMEDY_DETAIL = table.Column<string>(nullable: true),
                    OVERVIEW = table.Column<string>(nullable: true),
                    MANAGEMENT_VULN_YN = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VULN", x => x.VULN_SEQ);
                    table.ForeignKey(
                        name: "FK_T_VULN_T_VULN_GROUP_GROUP_SEQ",
                        column: x => x.GROUP_SEQ,
                        principalTable: "T_VULN_GROUP",
                        principalColumn: "GROUP_SEQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_VULN_GROUP_SEQ",
                table: "T_VULN",
                column: "GROUP_SEQ");

            migrationBuilder.CreateIndex(
                name: "IX_T_VULN_GROUP_COMP_SEQ",
                table: "T_VULN_GROUP",
                column: "COMP_SEQ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_VULN");

            migrationBuilder.DropTable(
                name: "T_VULN_GROUP");

            migrationBuilder.DropTable(
                name: "T_COMP_INFO");
        }
    }
}
