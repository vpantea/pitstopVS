using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations.IdentityServer.ConfigurationDb
{
    public partial class SeedConfigurationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 478, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 483, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 488, DateTimeKind.Utc).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 488, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 482, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 483, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 483, DateTimeKind.Utc).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 483, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 481, DateTimeKind.Utc).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 7, 11, 482, DateTimeKind.Utc).AddTicks(849));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 925, DateTimeKind.Utc).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 932, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 936, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 936, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 930, DateTimeKind.Utc).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 931, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 931, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 931, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 929, DateTimeKind.Utc).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 6, 19, 21, 4, 30, 930, DateTimeKind.Utc).AddTicks(264));
        }
    }
}
