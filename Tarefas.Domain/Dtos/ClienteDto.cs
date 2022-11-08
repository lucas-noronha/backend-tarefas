using Tarefas.Domain.Entidades;
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

        internal Cliente CriarOuAlterarEntidade(Cliente? cliente = null)
        {
            var referencia = cliente;

            if (referencia == null)
            {
                referencia = new Cliente();
                referencia.Id = Guid.NewGuid();
                referencia.DataCriacao = DateTime.Now;
            }

            referencia.Nome = Nome;
            referencia.Bairro = Bairro;
            referencia.Cidade = Cidade;
            referencia.UF = UF;
            referencia.Logradouro = Logradouro;
            referencia.Numero = Numero;
            referencia.Cep = Cep;

            return referencia;
        }

    }
}