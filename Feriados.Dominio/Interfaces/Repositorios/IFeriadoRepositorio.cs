using System.Collections.Generic;
using System.Threading.Tasks;
using Feriados.Dominio.Entidades;

namespace Feriados.Dominio.Interfaces.Repositorios
{
    public interface IFeriadoRepositorio
    {
        Task<IEnumerable<Feriado>> ObtemFeriados();
        Task<int> AdicionarFeriado(Feriado feriado);
        Task<int> AdicionarDatas(VariableDates datas);
        Task<bool> EditarFeriado(Feriado feriado);
        Task<bool> ExcluirFeriado(int id);
    }
}
