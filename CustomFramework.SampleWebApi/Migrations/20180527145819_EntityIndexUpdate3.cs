using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomFramework.SampleWebApi.Migrations
{
    public partial class EntityIndexUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "612938",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "543750");

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 58, 19, 37, DateTimeKind.Local), "1e8d8Gi2kzWhRxUoxKIk8w==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "Ar4h35ECAYeAxOQ2bvoH+njbX7jOpuhVNnkqJ0Yno/c=", new DateTime(2018, 5, 27, 17, 58, 19, 36, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 58, 19, 43, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 58, 19, 40, DateTimeKind.Local), "wvKPeXhGa1tdcXR8POgFcA==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 58, 19, 40, DateTimeKind.Local), "F1idmnDn3K5TRQtR83axZDB0v3YA0M0epRbELdkuD3Q=" });

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id_status",
                table: "user_roles",
                columns: new[] { "user_id", "status" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_roles_user_id_status",
                table: "user_roles");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "543750",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "612938");

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 53, 25, 956, DateTimeKind.Local), "JOBotHTSFtda3PEPids7AQ==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "pkCNun4gzEIMGy4zYCII0E15VWmJBGP7JInopN8KY04=", new DateTime(2018, 5, 27, 17, 53, 25, 956, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 959, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 17, 53, 25, 960, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 53, 25, 958, DateTimeKind.Local), "sXFs8XtiO3z9HG/A6ASCOg==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 27, 17, 53, 25, 958, DateTimeKind.Local), "ex5M2IZNuDANAqb6MM/dFlHowZVJdfnRVkI22hTYHsI=" });

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles",
                column: "user_id");
        }
    }
}
