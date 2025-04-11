using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hx.ArchivaFlow.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARC_ARCHIVES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ARCHIVE_NO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TITLE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    YEAR = table.Column<int>(type: "integer", nullable: false),
                    FILING_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    STATUS = table.Column<byte>(type: "smallint", nullable: false),
                    BUSINESS_KEY = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    REMARKS = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    EXTRAPROPERTIES = table.Column<string>(type: "text", nullable: false),
                    CONCURRENCYSTAMP = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CREATIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATORID = table.Column<Guid>(type: "uuid", nullable: true),
                    LASTMODIFICATIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LASTMODIFIERID = table.Column<Guid>(type: "uuid", nullable: true),
                    ISDELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DELETERID = table.Column<Guid>(type: "uuid", nullable: true),
                    DELETIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARC_ARCHIVES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ARC_METADATA",
                columns: table => new
                {
                    KEY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ARCHIVE_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    VALUE = table.Column<string>(type: "text", nullable: false),
                    DATA_TYPE = table.Column<byte>(type: "smallint", nullable: false),
                    NAVIGATION_PROPERTY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CREATIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATORID = table.Column<Guid>(type: "uuid", nullable: true),
                    LASTMODIFICATIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LASTMODIFIERID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARC_METADATA", x => new { x.ARCHIVE_ID, x.KEY });
                    table.ForeignKey(
                        name: "FK_ARC_METADATA_ARC_ARCHIVES_ARCHIVE_ID",
                        column: x => x.ARCHIVE_ID,
                        principalTable: "ARC_ARCHIVES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARC_ARCHIVES_ARCHIVE_NO",
                table: "ARC_ARCHIVES",
                column: "ARCHIVE_NO");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_ARCHIVES_BUSINESS_KEY",
                table: "ARC_ARCHIVES",
                column: "BUSINESS_KEY");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_ARCHIVES_FILING_DATE",
                table: "ARC_ARCHIVES",
                column: "FILING_DATE");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_ARCHIVES_STATUS",
                table: "ARC_ARCHIVES",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_ARCHIVES_TITLE",
                table: "ARC_ARCHIVES",
                column: "TITLE");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_ARCHIVES_YEAR",
                table: "ARC_ARCHIVES",
                column: "YEAR");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_METADATA_ARCHIVE_ID",
                table: "ARC_METADATA",
                column: "ARCHIVE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_METADATA_KEY",
                table: "ARC_METADATA",
                column: "KEY");

            migrationBuilder.CreateIndex(
                name: "IX_ARC_METADATA_VALUE",
                table: "ARC_METADATA",
                column: "VALUE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARC_METADATA");

            migrationBuilder.DropTable(
                name: "ARC_ARCHIVES");
        }
    }
}
