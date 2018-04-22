using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    custom_claim = table.Column<int>(nullable: false)
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    customer_no = table.Column<string>(maxLength: 25, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    surname = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_name = table.Column<string>(maxLength: 25, nullable: false),
                    password = table.Column<string>(maxLength: 256, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    email_confirmed = table.Column<bool>(nullable: false),
                    email_confirm_code = table.Column<string>(maxLength: 6, nullable: false, defaultValue: "339681"),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                        name: "fk_client_application_utils_client_applications_client_applica~",
                        column: x => x.client_application_id,
                        principalTable: "client_applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "current_accounts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    code = table.Column<string>(maxLength: 25, nullable: false),
                    customer_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_current_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_current_accounts_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                name: "user_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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

            migrationBuilder.InsertData(
                table: "client_applications",
                columns: new[] { "id", "client_application_code", "client_application_name", "client_application_password", "create_date_time", "delete_date_time", "status", "update_date_time" },
                values: new object[] { 1, "web", "web", "dFFYYAF+Nap7HJRxP80BzHYH4EHauzOrU4fOZnaEM+s=", new DateTime(2018, 4, 20, 20, 47, 19, 620, DateTimeKind.Local), null, 1, null });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "create_date_time", "delete_date_time", "description", "role_name", "status", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Administration Role", "Administrator", 1, null },
                    { 2, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Default User Role", "NormalUser", 1, null },
                    { 3, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "User for data writer like stats", "DataWriter", 1, null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "create_date_time", "delete_date_time", "email", "email_confirm_code", "email_confirmed", "lockout", "lockout_end_date_time", "password", "status", "update_date_time", "user_name" },
                values: new object[] { 1, 0, new DateTime(2018, 4, 20, 20, 47, 19, 623, DateTimeKind.Local), null, "admin@admin.org", "9988", false, false, null, "3u9G4bdO7NcJt++FQ0tlPeAaZrHg4v9vOsteUDxqfr8=", 1, null, "admin" });

            migrationBuilder.InsertData(
                table: "client_application_utils",
                columns: new[] { "id", "client_application_id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time" },
                values: new object[] { 1, 1, new DateTime(2018, 4, 20, 20, 47, 19, 621, DateTimeKind.Local), null, "dtJuWo6ezinXBnkyRrnU1Q==", 1, null });

            migrationBuilder.InsertData(
                table: "role_entity_claims",
                columns: new[] { "id", "can_create", "can_delete", "can_select", "can_update", "create_date_time", "delete_date_time", "entity", "role_id", "status", "update_date_time" },
                values: new object[,]
                {
                    { 18, true, false, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Player", 3, 1, null },
                    { 17, true, false, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Team", 3, 1, null },
                    { 16, true, false, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Match", 3, 1, null },
                    { 15, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Team", 1, 1, null },
                    { 14, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Stat", 1, 1, null },
                    { 13, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Player", 1, 1, null },
                    { 12, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Match", 1, 1, null },
                    { 11, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Role", 1, 1, null },
                    { 19, true, false, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Stat", 3, 1, null },
                    { 10, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "RoleEntityClaim", 1, 1, null },
                    { 8, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "User", 1, 1, null },
                    { 7, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "UserUtil", 1, 1, null },
                    { 6, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "UserRole", 1, 1, null },
                    { 5, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "UserEntityClaim", 1, 1, null },
                    { 4, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "UserClaim", 1, 1, null },
                    { 3, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "ClientApplication", 1, 1, null },
                    { 2, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "ClientApplicationUtil", 1, 1, null },
                    { 1, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "Claim", 1, 1, null },
                    { 9, true, true, true, true, new DateTime(2018, 4, 20, 20, 47, 19, 624, DateTimeKind.Local), null, "RoleClaim", 1, 1, null }
                });

            migrationBuilder.InsertData(
                table: "user_utils",
                columns: new[] { "id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time", "user_id" },
                values: new object[] { 1, new DateTime(2018, 4, 20, 20, 47, 19, 623, DateTimeKind.Local), null, "oqnbl3trQzFFV6r5ELizKA==", 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "ix_client_application_utils_client_application_id",
                table: "client_application_utils",
                column: "client_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_current_accounts_code",
                table: "current_accounts",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_current_accounts_customer_id",
                table: "current_accounts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_customers_customer_no",
                table: "customers",
                column: "customer_no",
                unique: true);

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
                name: "current_accounts");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "role_entity_claims");

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
                name: "customers");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
