namespace SimuladoIronFit.Api.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public int PersonalId { get; set; }
        public Personal? Personal { get; set; }
    }
}