using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomFramework.SampleWebApi.Migrations
{
    public partial class EntityIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "771052",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "972528");

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 16, 6, 44, 489, DateTimeKind.Local), "/zyDR7B4qDa4Bdc7knvzvg==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "2Nb+FO1hUELP331K++CqgvaRXmsc++jHErEKjcS92bc=", new DateTime(2018, 5, 27, 16, 6, 44, 488, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 492, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 16, 6, 44, 493, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 16, 6, 44, 491, DateTimeKind.Local), "3Z8Iubg+ENkW5paub9rZjg==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 27, 16, 6, 44, 491, DateTimeKind.Local), "qEmnRhwPks2jFsnBBUfchpNPCx0wM3TgahQWOvBVGSE=" });

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_can_create",
                table: "user_entity_claims",
                column: "can_create");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_can_delete",
                table: "user_entity_claims",
                column: "can_delete");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_can_select",
                table: "user_entity_claims",
                column: "can_select");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_can_update",
                table: "user_entity_claims",
                column: "can_update");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_can_create",
                table: "role_entity_claims",
                column: "can_create");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_can_delete",
                table: "role_entity_claims",
                column: "can_delete");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_can_select",
                table: "role_entity_claims",
                column: "can_select");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_can_update",
                table: "role_entity_claims",
                column: "can_update");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_can_create",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_can_delete",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_can_select",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_user_entity_claims_can_update",
                table: "user_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_can_create",
                table: "role_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_can_delete",
                table: "role_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_can_select",
                table: "role_entity_claims");

            migrationBuilder.DropIndex(
                name: "ix_role_entity_claims_can_update",
                table: "role_entity_claims");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirm_code",
                table: "users",
                maxLength: 6,
                nullable: false,
                defaultValue: "972528",
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldDefaultValue: "771052");

            migrationBuilder.UpdateData(
                table: "client_application_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 14, 15, 2, 180, DateTimeKind.Local), "O2ZvLEydhuc/gN+Dn63Lnw==" });

            migrationBuilder.UpdateData(
                table: "client_applications",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "client_application_password", "create_date_time" },
                values: new object[] { "gsd5C+UcCbGtLTMAupkWNcR6uTTs3ufX5HKm+nfgHZE=", new DateTime(2018, 5, 27, 14, 15, 2, 179, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 4,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 5,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 6,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 7,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 8,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 9,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 10,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 11,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 12,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 13,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 14,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "role_entity_claims",
                keyColumn: "id",
                keyValue: 15,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 182, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_date_time",
                value: new DateTime(2018, 5, 27, 14, 15, 2, 183, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "user_utils",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "special_value" },
                values: new object[] { new DateTime(2018, 5, 27, 14, 15, 2, 181, DateTimeKind.Local), "C88RgHGOUYfp2RbtCTJWKA==" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date_time", "password" },
                values: new object[] { new DateTime(2018, 5, 27, 14, 15, 2, 181, DateTimeKind.Local), "MNc49tiK5rbr80JBl6+N78YczR8yvTZgkwSzbk5V4RM=" });
        }
    }
}
