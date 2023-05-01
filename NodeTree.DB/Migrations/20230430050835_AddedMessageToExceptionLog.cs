using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeTree.DB.Migrations
{
    public partial class AddedMessageToExceptionLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ExceptionsLog",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "ExceptionsLog");
        }
    }
}
