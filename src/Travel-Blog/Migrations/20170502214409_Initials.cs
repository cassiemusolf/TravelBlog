using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBlog.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExperiencesPeoples_ExperienceId",
                table: "ExperiencesPeoples");

            migrationBuilder.DropIndex(
                name: "IX_ExperiencesPeoples_PeopleId",
                table: "ExperiencesPeoples");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ExperiencesPeoples_PeopleId",
                table: "ExperiencesPeoples",
                column: "PeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ExperiencesPeoples_PeopleId",
                table: "ExperiencesPeoples");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencesPeoples_ExperienceId",
                table: "ExperiencesPeoples",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencesPeoples_PeopleId",
                table: "ExperiencesPeoples",
                column: "PeopleId");
        }
    }
}
