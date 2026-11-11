namespace SimuladoIronFit.Api.Models.DTOs
{
    public class CriarAlunoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public int PersonalId { get; set; }
    }
}
