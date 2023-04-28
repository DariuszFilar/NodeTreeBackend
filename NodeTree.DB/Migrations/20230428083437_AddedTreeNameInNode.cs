using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeTree.DB.Migrations
{
    public partial class AddedTreeNameInNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TreeName",
                table: "Nodes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreeName",
                table: "Nodes");
        }
    }
}
