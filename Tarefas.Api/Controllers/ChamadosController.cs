using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.Annotations;
using Tarefas.Data.ConfiguracaoEntidades;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Servicos;

namespace Tarefas.Api.Controllers
{
    [Route("api/chamados")]
    [ApiController]
    public class ChamadosController : ControllerBase
    {
        public ChamadoServico ChamadoServico { get; }

        public ChamadosController(ChamadoServico servico)
        {
            ChamadoServico = servico;
        }

        [HttpGet("buscar/{id}")]
        [SwaggerOperation(summary: "Obter chamado", description: "Obtém um chamado pelo id (guid) informado na rota.")]
        [SwaggerResponse(200, "Chamado foi encontrado normalmente")]
        [SwaggerResponse(404, "Chamado não foi encontrado")]
        public IActionResult Obter(Guid id)
        {
            var chamado = ChamadoServico.ObterChamado(id);

            if (chamado == null)
            {
                return NotFound("Chamado não encontrado!");
            }
            return Ok(chamado);
        }

        [HttpGet("em_andamento")]
        [SwaggerOperation(summary: "Listar chamados em andamento", description: "Obtém uma lista de chamados que não se encontram FINALIZADOS ou CANCELADOS")]
        [SwaggerResponse(200, "Retornou a lista de chamados")]
        [SwaggerResponse(404, "Nenhum chamado em andamento foi encontrado")]
        public IActionResult ListarEmAndamento()
        {
            var chamados = ChamadoServico.ObterChamadosEmAndamento();

            if (!chamados.Any())
            {
                return NotFound("Nenhum chamado em andamento encontrado!");
            }

            return Ok(chamados);
        }

        [HttpGet("finalizados")]
        [SwaggerOperation(summary: "Listar chamados finalizados", description: "Obtém uma lista de chamados que se encontram FINALIZADOS ou CANCELADOS")]
        [SwaggerResponse(200, "Retornou a lista de chamados")]
        [SwaggerResponse(404, "Nenhum chamado finalizado ou cancelado foi encontrado")]
        public IActionResult ListarFinalizados()
        {
            var chamados = ChamadoServico.ObterChamadosFinalizados();

            if (!chamados.Any())
            {
                return NotFound("Nenhum chamado finalizado encontrado");
            }

            return Ok(chamados);
        }

        [HttpPost("cadastrar")]
        [SwaggerOperation(summary: "Cadastro de chamados", description: "Cadastra um chamado com base nas informações do dto")]
        [SwaggerResponse(200, "Chamado cadastrado com sucesso")]
        public IActionResult Cadastrar(ChamadoDto chamado)
        {
            var id = ChamadoServico.Cadastrar(chamado);

            return Ok($"Chamado cadastrado! ID: {id}");
        }

        [HttpPost("adicionar_tempo")]
        [SwaggerOperation(summary: "Adição de tempo gasto ao chamado", description: "Adiciona um novo registro de tempo gasto ao chamado")]
        [SwaggerResponse(200, "Tempo adicionado com sucesso")]
        public IActionResult AdicionarTempo(TempoGastoDto dto)
        {
            ChamadoServico.AdicionarTempoAoChamado(dto);
            var chamadoAtualizado = ChamadoServico.ObterChamado(dto.ChamadoId);

            return Ok(chamadoAtualizado);    
        }

        [HttpPost("adicionar_historico")]
        [SwaggerOperation(summary: "Adição de historico ao chamado", description: "Adiciona um novo histórico de atividade ao chamado")]
        [SwaggerResponse(200, "Histórico adicionado com sucesso")]
        public IActionResult AdicionarHistorico(HistoricoChamadoDto dto)
        {
            ChamadoServico.AdicionarHistorico(dto);
            var chamadoAtualizado = ChamadoServico.ObterChamado(dto.ChamadoId);

            return Ok(chamadoAtualizado);
        }


        [HttpPut("editar")]
        [SwaggerOperation(summary: "Edição de chamados", description: "Edita um chamado com base nas informações do dto")]
        [SwaggerResponse(200, "Histórico adicionado com sucesso")]
        public IActionResult Editar(ChamadoDto chamado)
        {
            ChamadoServico.Alterar(chamado);

            return Ok("Chamado editado com sucesso!");
        }

        [HttpDelete("remover_tempo/{id}")]
        [SwaggerOperation(summary: "Remoção de tempo do chamado", description: "Remove um registro de tempo gasto do chamado")]
        [SwaggerResponse(200, "Tempo removido com sucesso")]
        public IActionResult RemoverTempo(Guid id)
        {
            ChamadoServico.RemoverTempoGasto(id);

            return Ok();
        }

        [HttpDelete("remover_historico/{id}")]
        [SwaggerOperation(summary: "Remoção de histórico do chamado", description: "Remove um registro de atividade chamado")]
        [SwaggerResponse(200, "Histórico removido com sucesso")]
        public IActionResult RemoverHistorico(Guid id)
        {
            ChamadoServico.RemoverHistoricoDeChamado(id);

            return Ok();
        }

        [HttpDelete("cancelar/{id}")]
        [SwaggerOperation(summary: "Cancelamento de chamado", description: "Cancela uma solicitação de chamado")]
        [SwaggerResponse(200, "Chamado cancelado com sucesso")]
        public IActionResult Cancelar(Guid id)
        {
            ChamadoServico.Cancelar(id);

            return Ok("Chamado cancelado!");
        }

    }
}
