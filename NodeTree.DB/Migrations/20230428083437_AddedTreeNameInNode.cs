using Microsoft.EntityFrameworkCore.Migrations;


namespace NodeTree.DB.Migrations
{
    public partial class AddedTreeNameInNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<string>(
                name: "TreeName",
                table: "Nodes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "TreeName",
                table: "Nodes");
        }
    }
}
