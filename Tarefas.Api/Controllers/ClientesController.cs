using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(summary: "Obter clientes", description: "Obtém um cliente pelo id (guid) informado na rota.")]
        [SwaggerResponse(200, "Cliente foi encontrado normalmente")]
        [SwaggerResponse(404, "Cliente não foi encontrado")]
        public IActionResult Obter(Guid id)
        {
            var usuario = ClienteServico.ObterCliente(id);

            if (usuario == null)
            {
                return NotFound("Cliente não encontrado");
            }

            return Ok(usuario);
        }

        [HttpGet("buscar_lista")]
        [SwaggerOperation(summary: "Obter lista de clientes", description: "Obtém uma lista de clientes ATIVOS no banco de dados")]
        [SwaggerResponse(200, "Todos os clientes foram obtidos e retornados")]
        [SwaggerResponse(404, "Não há nenhum cliente ativo")]
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
        [SwaggerOperation(summary: "Cadastro de cliente", description: "Cadastra um cliente com base nas informações do dto")]
        [SwaggerResponse(200, "Cliente cadastrado com sucesso")]
        public IActionResult Cadastrar(ClienteDto cliente)
        {
            var clienteId = ClienteServico.Cadastrar(cliente);

            return Ok($"Cliente cadastrado com sucesso! ID: {clienteId}");
        }

        [HttpPut("editar")]
        [SwaggerOperation(summary: "Edição de cliente", description: "Edita um cliente com base nas informações do dto")]
        [SwaggerResponse(200, "Cliente editado com sucesso")]
        public IActionResult Editar(ClienteDto cliente)
        {
            ClienteServico.Alterar(cliente);

            return Ok("Cliente salvo com sucesso!");
        }

        [HttpDelete("inativar/{id}")]
        [SwaggerOperation(summary: "Inativação de cliente", description: "Inativa o cliente informado na rota")]
        [SwaggerResponse(200, "Cliente inativado com sucesso")]
        public IActionResult Inativar(Guid id)
        {
            ClienteServico.Inativar(id);

            return Ok("Cliente inativado com sucesso!");
        }
    }
}
