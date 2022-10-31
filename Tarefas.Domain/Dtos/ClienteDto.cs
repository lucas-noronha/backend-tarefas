using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces;

namespace Tarefas.Domain.Dtos
{
    public class ClienteDto
    {
        public ClienteDto() 
        {}
        internal ClienteDto(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            DataCriacao = cliente.DataCriacao;
            Bairro = cliente.Bairro;
            Cidade = cliente.Cidade;
            UF = cliente.UF;
            Logradouro = cliente.Logradouro;
            Numero = cliente.Numero;
            Cep = cliente.Cep;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }

        internal Cliente CriarEntidade()
        {
            return new Cliente(this);
        }
    }
}