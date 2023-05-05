using Microsoft.EntityFrameworkCore.Migrations;


namespace NodeTree.DB.Migrations
{
    public partial class AddedMessageToExceptionLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ExceptionsLog",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "Message",
                table: "ExceptionsLog");
        }
    }
}
