using Microsoft.EntityFrameworkCore.Migrations;


namespace NodeTree.DB.Migrations
{
    public partial class AddedParentIdAndVirtualChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<long>(
                name: "NodeId",
                table: "Nodes",
                type: "bigint",
                nullable: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Nodes_NodeId",
                table: "Nodes",
                column: "NodeId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_NodeId",
                table: "Nodes",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_NodeId",
                table: "Nodes");

            _ = migrationBuilder.DropIndex(
                name: "IX_Nodes_NodeId",
                table: "Nodes");

            _ = migrationBuilder.DropColumn(
                name: "NodeId",
                table: "Nodes");
        }
    }
}
