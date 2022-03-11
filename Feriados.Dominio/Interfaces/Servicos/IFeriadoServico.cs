using System.Collections.Generic;
using System.Threading.Tasks;
using Feriados.Dominio.Entidades;
using Feriados.Dominio.Respostas;

namespace Feriados.Dominio.Interfaces
{
    public interface IFeriadoServico
    {
        Task<IEnumerable<Feriado>> ObtemFeriados();
        Task<IEnumerable<FeriadoResposta>> ObtemFeriadosApi();
        Task ProcessaFeriados();
    }
}
