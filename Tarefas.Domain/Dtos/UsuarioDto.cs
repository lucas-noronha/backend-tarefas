﻿using System.Text.Json.Serialization;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Enums;
using Tarefas.Domain.Handlers;

namespace Tarefas.Domain.Dtos
{
    public class UsuarioDto
    {
        public UsuarioDto()
        { }
        internal UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            DataCriacao = usuario.DataCriacao;
            Login = usuario.Login;
            TipoUsuario = usuario.TipoUsuario;

            Tarefas = usuario.Tarefas?.Select(x => new ChamadoDto(x)).ToList();
        }
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }

        [JsonIgnore]
        public List<ChamadoDto>? Tarefas { get; set; }

        internal Usuario CriarOuAlterarEntidade(Usuario? usuario = null)
        {
            var hash = new HashHandler();

            var referencia = usuario;
            if (referencia == null)
            {
                referencia = new Usuario();
                referencia.Id = Guid.NewGuid();
                referencia.DataCriacao = DateTime.Now;
                referencia.Senha = hash.CriptografarSenha(Senha);
            }

            referencia.Nome = Nome;
            referencia.Login = Login;
            referencia.TipoUsuario = TipoUsuario;
            return referencia;

        }
    }
}