using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeTree.DB.Migrations
{
    public partial class ChangedTimeStampToCreatedAtInExceptionLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "ExceptionsLog",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ExceptionsLog",
                newName: "Timestamp");
        }
    }
}
