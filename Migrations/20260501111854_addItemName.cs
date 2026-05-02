using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoiceApp.Migrations
{
    /// <inheritdoc />
    public partial class addItemName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "InvoiceItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "InvoiceItems");
        }
    }
}
