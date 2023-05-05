using Microsoft.EntityFrameworkCore.Migrations;


namespace NodeTree.DB.Migrations
{
    public partial class ChangedTimeStampToCreatedAtInExceptionLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "ExceptionsLog",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ExceptionsLog",
                newName: "Timestamp");
        }
    }
}
