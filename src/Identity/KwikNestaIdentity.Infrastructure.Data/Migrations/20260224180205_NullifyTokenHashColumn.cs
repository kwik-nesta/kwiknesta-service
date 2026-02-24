using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KwikNestaIdentity.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullifyTokenHashColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TokenHash",
                schema: "kn-identity-svc",
                table: "OtpEntries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TokenHash",
                schema: "kn-identity-svc",
                table: "OtpEntries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
