using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Interfaces.Repositorios;
using Tarefas.Domain.Servicos;

namespace Tarefas.Api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuarioServico UsuarioServico { get; }

        public UsuariosController(UsuarioServico servico)
        {
            UsuarioServico = servico;
        }

        [SwaggerOperation(summary: "Obter usuario", description: "Obtém um usuário pelo id (guid) informado na rota.")]
        [SwaggerResponse(200, "Usuário foi encontrado normalmente")]
        [SwaggerResponse(404, "Usuário não foi encontrado")]
        [HttpGet("buscar/{id}")]
        public IActionResult ObterUsuario(Guid id)
        {
            var usuario = UsuarioServico.ObterUsuario(id);

            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }

            return Ok(usuario);
        }

        [HttpGet("buscar_lista")]
        [SwaggerOperation(summary: "Obter lista de usuários", description: "Obtém uma lista de usuários ATIVOS no banco de dados")]
        [SwaggerResponse(200, "Todos os usuários foram obtidos e retornados")]
        [SwaggerResponse(404, "Não há nenhum usuário ativo")]
        public IActionResult ObterLista()
        {
            var lista = UsuarioServico.ObterUsuarios();
            
            if (!lista.Any())
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        [SwaggerOperation(summary: "Cadastro de usuário", description: "Cadastra um usuário com base nas informações do dto")]
        [SwaggerResponse(200, "Usuário cadastrado com sucesso")]
        public IActionResult Cadastrar(UsuarioDto usuario)
        {
            var usuarioId = UsuarioServico.Cadastrar(usuario);

            return Ok($"Usuário cadastrado com sucesso! ID: {usuarioId}");
        }

        [HttpPut("editar")]
        [SwaggerOperation(summary: "Edição de usuário", description: "Edita um usuário com base nas informações do dto")]
        [SwaggerResponse(200, "Usuário editado com sucesso")]
        public IActionResult Editar(UsuarioDto usuario)
        {
            UsuarioServico.Alterar(usuario);

            return Ok("Usuario salvo com sucesso!");
        }

        [HttpDelete("inativar/{id}")]
        [SwaggerOperation(summary: "Inativação de usuário", description: "Inativa o usuário informado na rota")]
        [SwaggerResponse(200, "Usuário inativado com sucesso")]
        public IActionResult Inativar(Guid id)
        {
            UsuarioServico.Inativar(id);

            return Ok("Usuário inativado com sucesso!");
        }

    }
}
