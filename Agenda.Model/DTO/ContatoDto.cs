namespace Agenda.Model.DTO
{
    public class ContatoDto
    {
        public required string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public required string Email { get; set; }
        public required int Ddd { get; set; }
    }
}
