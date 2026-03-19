using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KwikNestaInfra.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeCountryISO2ColumnIndexNonUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_ISO2",
                schema: "kn-infra-svc",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ISO2",
                schema: "kn-infra-svc",
                table: "Countries",
                column: "ISO2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_ISO2",
                schema: "kn-infra-svc",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ISO2",
                schema: "kn-infra-svc",
                table: "Countries",
                column: "ISO2",
                unique: true);
        }
    }
}
