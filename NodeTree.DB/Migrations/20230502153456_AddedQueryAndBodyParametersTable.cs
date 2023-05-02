using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NodeTree.DB.Migrations
{
    public partial class AddedQueryAndBodyParametersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyParameters",
                table: "ExceptionsLog");

            migrationBuilder.DropColumn(
                name: "QueryParameters",
                table: "ExceptionsLog");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExceptionsLog",
                newName: "ExceptionLogId");

            migrationBuilder.CreateTable(
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
                    table.PrimaryKey("PK_BodyParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyParameters_ExceptionsLog_ExceptionLogId",
                        column: x => x.ExceptionLogId,
                        principalTable: "ExceptionsLog",
                        principalColumn: "ExceptionLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
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
                    table.PrimaryKey("PK_QueryParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueryParameters_ExceptionsLog_ExceptionLogId",
                        column: x => x.ExceptionLogId,
                        principalTable: "ExceptionsLog",
                        principalColumn: "ExceptionLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyParameters_ExceptionLogId",
                table: "BodyParameters",
                column: "ExceptionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryParameters_ExceptionLogId",
                table: "QueryParameters",
                column: "ExceptionLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyParameters");

            migrationBuilder.DropTable(
                name: "QueryParameters");

            migrationBuilder.RenameColumn(
                name: "ExceptionLogId",
                table: "ExceptionsLog",
                newName: "Id");

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "BodyParameters",
                table: "ExceptionsLog",
                type: "hstore",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "QueryParameters",
                table: "ExceptionsLog",
                type: "hstore",
                nullable: true);
        }
    }
}
