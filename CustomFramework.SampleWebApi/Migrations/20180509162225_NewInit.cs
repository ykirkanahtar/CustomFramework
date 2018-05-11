using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomFramework.SampleWebApi.Migrations
{
    public partial class NewInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    custom_claim = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_applications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    client_application_name = table.Column<string>(maxLength: 20, nullable: false),
                    client_application_code = table.Column<string>(maxLength: 6, nullable: false),
                    client_application_password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_applications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    role_name = table.Column<string>(maxLength: 25, nullable: false),
                    description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    student_no = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    surname = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    teacher_no = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    surname = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_name = table.Column<string>(maxLength: 25, nullable: false),
                    password = table.Column<string>(maxLength: 256, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    email_confirmed = table.Column<bool>(nullable: false),
                    email_confirm_code = table.Column<string>(maxLength: 6, nullable: false, defaultValue: "550579"),
                    access_failed_count = table.Column<int>(nullable: false, defaultValue: 0),
                    lockout = table.Column<bool>(nullable: false),
                    lockout_end_date_time = table.Column<DateTime>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_application_utils",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    client_application_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_application_utils", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_application_utils_client_applications_client_application_id",
                        column: x => x.client_application_id,
                        principalTable: "client_applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_entity_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(maxLength: 50, nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_entity_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_entity_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    course_no = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    teacher_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courses", x => x.id);
                    table.ForeignKey(
                        name: "fk_courses_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_entity_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(maxLength: 50, nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_entity_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_entity_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_utils",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_utils", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_utils_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_courses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    student_id = table.Column<int>(nullable: false),
                    course_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_courses", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_courses_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_courses_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "client_applications",
                columns: new[] { "id", "client_application_code", "client_application_name", "client_application_password", "create_date_time", "delete_date_time", "status", "update_date_time" },
                values: new object[] { 1, "web", "web", "fQuvbeTFvQNfpOaUToUkjT52aY4sSAMjuC7L6smZ67c=", new DateTime(2018, 5, 9, 19, 22, 25, 473, DateTimeKind.Local), null, 1, null });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "create_date_time", "delete_date_time", "description", "role_name", "status", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "Administration Role", "Administrator", 1, null },
                    { 2, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "Default User Role", "NormalUser", 1, null },
                    { 3, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "User for data writer like stats", "DataWriter", 1, null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "create_date_time", "delete_date_time", "email", "email_confirm_code", "email_confirmed", "lockout", "lockout_end_date_time", "password", "status", "update_date_time", "user_name" },
                values: new object[] { 1, 0, new DateTime(2018, 5, 9, 19, 22, 25, 475, DateTimeKind.Local), null, "admin@admin.org", "9988", false, false, null, "nBzXnfWQ18CMgwExTGGbiAPipQCgN3ydWooNVEtZ2HQ=", 1, null, "admin" });

            migrationBuilder.InsertData(
                table: "client_application_utils",
                columns: new[] { "id", "client_application_id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time" },
                values: new object[] { 1, 1, new DateTime(2018, 5, 9, 19, 22, 25, 474, DateTimeKind.Local), null, "chxeceL4fLlildLjKYC+Bw==", 1, null });

            migrationBuilder.InsertData(
                table: "role_entity_claims",
                columns: new[] { "id", "can_create", "can_delete", "can_select", "can_update", "create_date_time", "delete_date_time", "entity", "role_id", "status", "update_date_time" },
                values: new object[,]
                {
                    { 14, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "Teacher", 1, 1, null },
                    { 13, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "Course", 1, 1, null },
                    { 12, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "Student", 1, 1, null },
                    { 11, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "Role", 1, 1, null },
                    { 10, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "RoleEntityClaim", 1, 1, null },
                    { 9, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "RoleClaim", 1, 1, null },
                    { 15, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "StudentCourse", 1, 1, null },
                    { 8, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "User", 1, 1, null },
                    { 6, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "UserRole", 1, 1, null },
                    { 5, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "UserEntityClaim", 1, 1, null },
                    { 4, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "UserClaim", 1, 1, null },
                    { 3, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "ClientApplication", 1, 1, null },
                    { 2, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "ClientApplicationUtil", 1, 1, null },
                    { 1, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "Claim", 1, 1, null },
                    { 7, true, true, true, true, new DateTime(2018, 5, 9, 19, 22, 25, 476, DateTimeKind.Local), null, "UserUtil", 1, 1, null }
                });

            migrationBuilder.InsertData(
                table: "user_utils",
                columns: new[] { "id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time", "user_id" },
                values: new object[] { 1, new DateTime(2018, 5, 9, 19, 22, 25, 475, DateTimeKind.Local), null, "rzdb2RTqHqgWit46KuE3Iw==", 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "ix_client_application_utils_client_application_id",
                table: "client_application_utils",
                column: "client_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_courses_course_no",
                table: "courses",
                column: "course_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_courses_teacher_id",
                table: "courses",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_claim_id",
                table: "role_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id",
                table: "role_entity_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_courses_course_id",
                table: "student_courses",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_courses_student_id",
                table: "student_courses",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_student_no",
                table: "students",
                column: "student_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_teachers_teacher_no",
                table: "teachers",
                column: "teacher_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_claim_id",
                table: "user_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_user_id",
                table: "user_entity_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_utils_user_id",
                table: "user_utils",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_application_utils");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "role_entity_claims");

            migrationBuilder.DropTable(
                name: "student_courses");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_entity_claims");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_utils");

            migrationBuilder.DropTable(
                name: "client_applications");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
