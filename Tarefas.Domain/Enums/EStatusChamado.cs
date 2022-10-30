using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Enums
{
    public enum EStatusChamado
    {
        Pendente = 0,
        EmAndamento = 1,
        AguardandoRetorno = 2,
        Finalizado = 3,
        Cancelado = 4
    }
}
