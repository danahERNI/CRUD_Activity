using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemList.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "ItemModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Serial",
                table: "ItemModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
