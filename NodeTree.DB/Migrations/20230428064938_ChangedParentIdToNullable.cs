using Microsoft.EntityFrameworkCore.Migrations;


namespace NodeTree.DB.Migrations
{
    public partial class ChangedParentIdToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Nodes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Nodes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
