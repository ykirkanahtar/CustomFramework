using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomFramework.SampleWebApi.Migrations
{
    public partial class EntityIndexUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "957783",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "813271");

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 27, 45, 659, DateTimeKind.Local), "0i+avSkoJ/YLj+EDnGiV5w==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "QUVtROI2WywBRowiNSiwESA4YEDzN2Q0rnzpvidYd2o=", new DateTime(2018, 5, 27, 17, 27, 45, 658, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 27, 45, 662, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 27, 45, 660, DateTimeKind.Local), "CBP5QDIKg/9iU/h59Iyx1w==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 27, 45, 660, DateTimeKind.Local), "b+qg8vYGW+eVYCKAiZqUtb4T1QGAQrEwauo0lBfHffk=" });

            migrationBuilder.CreateIndex(
                name: "ix_users_status",
                table: "users",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_utils_status",
                table: "user_utils",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_status",
                table: "user_roles",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_status",
                table: "user_entity_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_status",
                table: "user_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_teachers_status",
                table: "teachers",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_students_status",
                table: "students",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_student_courses_status",
                table: "student_courses",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_roles_status",
                table: "roles",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_status",
                table: "role_entity_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_status",
                table: "role_claims",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_courses_status",
                table: "courses",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_client_applications_status",
                table: "client_applications",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_client_application_utils_status",
                table: "client_application_utils",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_claims_status",
                table: "claims",
                column: "status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_status",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_user_utils_status",
                table: "user_utils");

            migrationBuilder.DropIndex(
                name: "ix_user_roles_status",
                table: "user_roles");

            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_status",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_user_claims_status",
                table: "user_claims");

            migrationBuilder.DropIndex(
                name: "ix_teachers_status",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "ix_students_status",
                table: "students");

            migrationBuilder.DropIndex(
                name: "ix_student_courses_status",
                table: "student_courses");

            migrationBuilder.DropIndex(
                name: "ix_roles_status",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_status",
                table: "role_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_claims_status",
                table: "role_claims");

            migrationBuilder.DropIndex(
                name: "ix_courses_status",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "ix_client_applications_status",
                table: "client_applications");

            migrationBuilder.DropIndex(
                name: "ix_client_application_utils_status",
                table: "client_application_utils");

            migrationBuilder.DropIndex(
                name: "ix_claims_status",
                table: "claims");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "813271",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "957783");

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 17, 25, 179, DateTimeKind.Local), "cywC2RISmodkyFPQOt4QMw==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "JKz11+7SGUkWbuJeMLHV/iRxdmumk5mUrdFRjjtjRqU=", new DateTime(2018, 5, 27, 17, 17, 25, 178, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 181, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 181, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 17, 25, 181, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 17, 25, 180, DateTimeKind.Local), "x5B5A/9MpqPoJGDc4C7Fxw==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 17, 25, 180, DateTimeKind.Local), "92yHgHc7LcPpWNFwv/zmxNVTGCCCXHHxoKk2uLrItwc=" });
        }
    }
}
