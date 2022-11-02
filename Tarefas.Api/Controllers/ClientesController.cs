using Microsoft.AspNetCore.Mvc;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Servicos;

namespace Tarefas.Api.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public ClienteServico ClienteServico { get; }

        public ClientesController(ClienteServico servico)
        {
            ClienteServico = servico;
        }

        [HttpGet("buscar/{id}")]
        public IActionResult ObterUsuario(Guid id)
        {
            var usuario = ClienteServico.ObterCliente(id);

            if (usuario == null)
            {
                return NotFound("Cliente não encontrado");
            }

            return Ok(usuario);
        }

        [HttpGet("buscar_lista")]
        public IActionResult ObterLista()
        {
            var lista = ClienteServico.ObterClientes();

            if (!lista.Any())
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(ClienteDto cliente)
        {
            var clienteId = ClienteServico.Cadastrar(cliente);

            return Ok("Cliente cadastrado com sucesso!");
        }

        [HttpPut("editar")]
        public IActionResult Editar(ClienteDto cliente)
        {
            ClienteServico.Alterar(cliente);

            return Ok("Cliente salvo com sucesso!");
        }

        [HttpDelete("inativar/{id}")]
        public IActionResult Inativar(Guid id)
        {
            ClienteServico.Inativar(id);

            return Ok("Cliente inativado com sucesso!");
        }
    }
}
