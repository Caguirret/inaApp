using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "tbProducto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbCategoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbProducto_IdCategoria",
                table: "tbProducto",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProducto_tbCategoria_IdCategoria",
                table: "tbProducto",
                column: "IdCategoria",
                principalTable: "tbCategoria",
                principalColumn: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProducto_tbCategoria_IdCategoria",
                table: "tbProducto");

            migrationBuilder.DropTable(
                name: "tbCategoria");

            migrationBuilder.DropIndex(
                name: "IX_tbProducto_IdCategoria",
                table: "tbProducto");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "tbProducto");
        }
    }
}
