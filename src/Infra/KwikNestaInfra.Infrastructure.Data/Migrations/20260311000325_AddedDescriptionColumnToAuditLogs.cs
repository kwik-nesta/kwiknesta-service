using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KwikNestaInfra.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionColumnToAuditLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "kn-infra-svc",
                table: "AuditLogs",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "kn-infra-svc",
                table: "AuditLogs");
        }
    }
}
