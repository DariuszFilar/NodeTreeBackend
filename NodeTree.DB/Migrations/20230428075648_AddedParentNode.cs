using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;


namespace NodeTree.DB.Migrations
{
    public partial class AddedParentNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_NodeId",
                table: "Nodes");

            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes");

            _ = migrationBuilder.DropIndex(
                name: "IX_Nodes_NodeId",
                table: "Nodes");

            _ = migrationBuilder.DropColumn(
                name: "Id",
                table: "Nodes");

            _ = migrationBuilder.AlterColumn<long>(
                name: "NodeId",
                table: "Nodes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes",
                column: "NodeId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId",
                principalTable: "Nodes",
                principalColumn: "NodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes");

            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes");

            _ = migrationBuilder.DropIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes");

            _ = migrationBuilder.AlterColumn<long>(
                name: "NodeId",
                table: "Nodes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            _ = migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Nodes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes",
                column: "Id");

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
    }
}
