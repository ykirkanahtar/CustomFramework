using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomFramework.SampleWebApi.Migrations
{
    public partial class EntityIndexUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_user_id_entity_can_create_can_select_can_update_can_delete",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_role_id_entity_can_create_can_select_can_update_can_delete",
                table: "role_entity_claims");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "543750",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "957783");

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
                name: "ix_user_entity_claims_user_id_entity_can_create",
                table: "user_entity_claims",
                columns: new[] { "user_id", "entity", "can_create" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_user_id_entity_can_delete",
                table: "user_entity_claims",
                columns: new[] { "user_id", "entity", "can_delete" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_user_id_entity_can_select",
                table: "user_entity_claims",
                columns: new[] { "user_id", "entity", "can_select" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_user_id_entity_can_update",
                table: "user_entity_claims",
                columns: new[] { "user_id", "entity", "can_update" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id_entity_can_create",
                table: "role_entity_claims",
                columns: new[] { "role_id", "entity", "can_create" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id_entity_can_delete",
                table: "role_entity_claims",
                columns: new[] { "role_id", "entity", "can_delete" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id_entity_can_select",
                table: "role_entity_claims",
                columns: new[] { "role_id", "entity", "can_select" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id_entity_can_update",
                table: "role_entity_claims",
                columns: new[] { "role_id", "entity", "can_update" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_user_id_entity_can_create",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_user_id_entity_can_delete",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_user_id_entity_can_select",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_user_id_entity_can_update",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_role_id_entity_can_create",
                table: "role_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_role_id_entity_can_delete",
                table: "role_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_role_id_entity_can_select",
                table: "role_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_role_id_entity_can_update",
                table: "role_entity_claims");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "957783",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "543750");

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
                name: "ix_user_entity_claims_user_id_entity_can_create_can_select_can_update_can_delete",
                table: "user_entity_claims",
                columns: new[] { "user_id", "entity", "can_create", "can_select", "can_update", "can_delete" });

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id_entity_can_create_can_select_can_update_can_delete",
                table: "role_entity_claims",
                columns: new[] { "role_id", "entity", "can_create", "can_select", "can_update", "can_delete" });
        }
    }
}
