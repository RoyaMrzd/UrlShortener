using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Persistence.Migrations
{
    public partial class AddAccessHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortestCount",
                table: "UrlShortener");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UrlShortener",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedUserId",
                table: "UrlShortener",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "UrlShortenerAccessHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlShortenerEntityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlShortenerAccessHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrlShortenerAccessHistory_UrlShortener_UrlShortenerEntityId",
                        column: x => x.UrlShortenerEntityId,
                        principalTable: "UrlShortener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlShortenerAccessHistory_UrlShortenerEntityId",
                table: "UrlShortenerAccessHistory",
                column: "UrlShortenerEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlShortenerAccessHistory");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "UrlShortener",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModifiedUserId",
                table: "UrlShortener",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShortestCount",
                table: "UrlShortener",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
