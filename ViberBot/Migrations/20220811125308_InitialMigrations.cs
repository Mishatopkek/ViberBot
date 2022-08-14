using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViberBot.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = System.IO.File.ReadAllText(
                "Migrations/Extensions/TrackLocations.sql");
            migrationBuilder.Sql(sql);
            sql = System.IO.File.ReadAllText(
                "Migrations/Extensions/CreateFunctionGeodist.sql");
            migrationBuilder.Sql(sql);
            sql = System.IO.File.ReadAllText(
                "Migrations/Extensions/CreateProcedureShowSumStatisticsById.sql");
            migrationBuilder.Sql(sql);
            sql = System.IO.File.ReadAllText(
                "Migrations/Extensions/CreateProcedureShowTopStatisticsById.sql");
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = System.IO.File.ReadAllText(
                "ViberBot/Migrations/Extensions/DownInitialMigrations.sql");
            migrationBuilder.Sql(sql);
        }
    }
}
