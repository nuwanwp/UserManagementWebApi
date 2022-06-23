using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementModule.Data.Migrations
{
    public partial class initialmigrationandseedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessRule",
                columns: table => new
                {
                    AccessRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRule", x => x.AccessRuleId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.UserGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Privilege = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AttachedCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUser_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUser_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "UserGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupRuleAssignment",
                columns: table => new
                {
                    UserGroupId = table.Column<int>(type: "int", nullable: false),
                    AccessRuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupRuleAssignment", x => new { x.UserGroupId, x.AccessRuleId });
                    table.ForeignKey(
                        name: "FK_UserGroupRuleAssignment_AccessRule_AccessRuleId",
                        column: x => x.AccessRuleId,
                        principalTable: "AccessRule",
                        principalColumn: "AccessRuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupRuleAssignment_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "UserGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccessRule",
                columns: new[] { "AccessRuleId", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Permission", "RuleName" },
                values: new object[] { 1, "NUWANW", new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6115), null, null, true, "CUSTOMER_PROFILE_ACCESS" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "NUWANW", new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(5887), "JOHN@GMAIL.COM", "JOHN", "DOE", null, null },
                    { 2, "NUWANW", new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6007), "SMITH@GMAIL.COM", "GEORGE", "SMITH", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserGroup",
                columns: new[] { "UserGroupId", "CreatedBy", "CreatedDate", "GroupName", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "NUWANW", new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6061), "FRONTDESK", null, null },
                    { 2, "NUWANW", new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6063), "RECEPTIONIST", null, null }
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "Id", "Privilege" },
                values: new object[] { 1, "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "SystemUser",
                columns: new[] { "Id", "AttachedCustomerId", "UserGroupId" },
                values: new object[] { 2, "100001", 1 });

            migrationBuilder.InsertData(
                table: "UserGroupRuleAssignment",
                columns: new[] { "AccessRuleId", "UserGroupId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_UserGroupId",
                table: "SystemUser",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupRuleAssignment_AccessRuleId",
                table: "UserGroupRuleAssignment",
                column: "AccessRuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "UserGroupRuleAssignment");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "AccessRule");

            migrationBuilder.DropTable(
                name: "UserGroup");
        }
    }
}
