using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult ObterLista()
        {
            var lista = UsuarioServico.ObterUsuarios();
            
            if (!lista.Any())
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(UsuarioDto usuario)
        {
            var usuarioId = UsuarioServico.Cadastrar(usuario);

            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPut("editar")]
        public IActionResult Editar(UsuarioDto usuario)
        {
            UsuarioServico.Alterar(usuario);

            return Ok("Usuario salvo com sucesso!");
        }

        [HttpDelete("inativar/{id}")]
        public IActionResult Inativar(Guid id)
        {
            UsuarioServico.Inativar(id);

            return Ok("Usuário inativado com sucesso!");
        }

    }
}
