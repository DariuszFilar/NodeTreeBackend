using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;


namespace NodeTree.DB.Migrations
{
    public partial class AddedQueryAndBodyParametersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "BodyParameters",
                table: "ExceptionsLog");

            _ = migrationBuilder.DropColumn(
                name: "QueryParameters",
                table: "ExceptionsLog");

            _ = migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExceptionsLog",
                newName: "ExceptionLogId");

            _ = migrationBuilder.CreateTable(
                name: "BodyParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ExceptionLogId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_BodyParameters", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_BodyParameters_ExceptionsLog_ExceptionLogId",
                        column: x => x.ExceptionLogId,
                        principalTable: "ExceptionsLog",
                        principalColumn: "ExceptionLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "QueryParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ExceptionLogId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_QueryParameters", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_QueryParameters_ExceptionsLog_ExceptionLogId",
                        column: x => x.ExceptionLogId,
                        principalTable: "ExceptionsLog",
                        principalColumn: "ExceptionLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_BodyParameters_ExceptionLogId",
                table: "BodyParameters",
                column: "ExceptionLogId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_QueryParameters_ExceptionLogId",
                table: "QueryParameters",
                column: "ExceptionLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "BodyParameters");

            _ = migrationBuilder.DropTable(
                name: "QueryParameters");

            _ = migrationBuilder.RenameColumn(
                name: "ExceptionLogId",
                table: "ExceptionsLog",
                newName: "Id");

            _ = migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "BodyParameters",
                table: "ExceptionsLog",
                type: "hstore",
                nullable: true);

            _ = migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "QueryParameters",
                table: "ExceptionsLog",
                type: "hstore",
                nullable: true);
        }
    }
}
