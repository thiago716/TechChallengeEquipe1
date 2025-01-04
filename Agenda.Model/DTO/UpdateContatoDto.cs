using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Model.DTO
{
    public class UpdateContatoDto
    {
        public int id { get; set; }
        public required string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public required string Email { get; set; }
        public required int Ddd { get; set; }
    }
}
