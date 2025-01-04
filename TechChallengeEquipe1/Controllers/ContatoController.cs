using Agenda.Model.DTO;
using Agenda.Model.Entity;
using Agenda.Model.Interface;
using Agenda.Model.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IRepository _repo;

        public ContatoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_repo.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContatoDto input)
        {
            try
            {
                var validationError = ValidaContato(input);
                if (validationError != null)
                {
                    return validationError;
                }
                var contato = new Contato()
                {
                    Nome = input.Nome,
                    Ddd = input.Ddd,
                    Email = input.Email,
                    Telefone = input.Telefone,
                    Celular = input.Celular,
                };

                _repo.Cadastrar(contato);
                return Ok(contato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult BuscarPorDdd(int ddd)
        {
            return Ok(_repo.BuscarPorDdd(ddd));
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateContatoDto input)
        {
            try
            {
                var validationError = ValidaContato(input);
                if (validationError != null)
                {
                    return validationError;
                }

                var contato = _repo.ObterPorId(input.id);
                contato.Nome = input.Nome;
                contato.Ddd = input.Ddd;
                contato.Telefone = input.Telefone;
                contato.Celular = input.Celular;
                contato.Email = input.Email;
                _repo.Alterar(contato);
                return Ok(contato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _repo.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private IActionResult ValidaContato(ContatoDto input)
        {
            // Verifica a validade do DDD
            if (!Helper.ValidarDdd(input.Ddd))
                return BadRequest("DDD não é válido.");

            if (!Helper.ValidarEmail(input.Email))
                return BadRequest("Email não é válido.");

            // Verifica se ambos os campos estão vazios ou em branco
            bool isTelefoneValid = !string.IsNullOrWhiteSpace(input.Telefone) && Helper.ValidarTelefone(input.Telefone);
            bool isCelularValid = !string.IsNullOrWhiteSpace(input.Celular) && Helper.ValidarCelular(input.Celular);
            
            // Valida o telefone
            if (!isTelefoneValid && !isCelularValid)
            {
                return BadRequest("Pelo menos um dos campos (Telefone ou Celular) deve ser preenchido e devem ser válidos.");
            }

            // Valida o telefone específico caso ele não seja válido
            if (!isTelefoneValid)
            {
                if (!isCelularValid)
                {
                    return BadRequest("Telefone deve ser válido.");
                }
                
            }

            // Valida o celular específico caso ele não seja válido
            if (!isCelularValid)
            {
                if (!isTelefoneValid)
                {
                    return BadRequest("Celular deve ser válido.");
                }
                
            }

            // Se todas as validações passarem, retorna null indicando que não há erros
            return null;
        }

        private IActionResult ValidaContato(UpdateContatoDto input)
        {
            // Verifica a validade do DDD
            if (!Helper.ValidarDdd(input.Ddd))
                return BadRequest("DDD não é válido.");

            if (!Helper.ValidarEmail(input.Email))
                return BadRequest("Email não é válido.");

            // Verifica se ambos os campos estão vazios ou em branco
            bool isTelefoneValid = !string.IsNullOrWhiteSpace(input.Telefone) && Helper.ValidarTelefone(input.Telefone);
            bool isCelularValid = !string.IsNullOrWhiteSpace(input.Celular) && Helper.ValidarCelular(input.Celular);

            // Valida o telefone
            if (!isTelefoneValid && !isCelularValid)
            {
                return BadRequest("Pelo menos um dos campos (Telefone ou Celular) deve ser preenchido e devem ser válidos.");
            }

            // Valida o telefone específico caso ele não seja válido
            if (!isTelefoneValid)
            {
                if (!isCelularValid)
                {
                    return BadRequest("Telefone deve ser válido.");
                }

            }

            // Valida o celular específico caso ele não seja válido
            if (!isCelularValid)
            {
                if (!isTelefoneValid)
                {
                    return BadRequest("Celular deve ser válido.");
                }

            }

            // Se todas as validações passarem, retorna null indicando que não há erros
            return null;
        }
    }
}
