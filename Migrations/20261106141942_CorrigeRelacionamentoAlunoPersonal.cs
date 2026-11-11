using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladoIronFit.Api.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeRelacionamentoAlunoPersonal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personais_Alunos_AlunoId",
                table: "Personais");

            migrationBuilder.DropIndex(
                name: "IX_Personais_AlunoId",
                table: "Personais");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Personais");

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_PersonalId",
                table: "Alunos",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Personais_PersonalId",
                table: "Alunos",
                column: "PersonalId",
                principalTable: "Personais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Personais_PersonalId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_PersonalId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Personais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personais_AlunoId",
                table: "Personais",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personais_Alunos_AlunoId",
                table: "Personais",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
