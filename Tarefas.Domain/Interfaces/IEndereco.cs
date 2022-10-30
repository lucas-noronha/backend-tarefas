using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Interfaces
{
    internal interface IEndereco
    {
        string Bairro { get; set; }

        string Cidade { get; set; }

        string UF { get; set; }

        string Logradouro { get; set; }

        string Numero { get; set; }

        string Cep { get; set; }

    }
}
