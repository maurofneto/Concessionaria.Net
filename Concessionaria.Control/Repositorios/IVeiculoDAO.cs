using System.Collections.Generic;
using Concessionaria.Control.Entidades;

namespace Concessionaria.Control.Repositorios
{
    public interface IVeiculoDAO:IRepositorio<Veiculo>
    {
        IList<Veiculo> PesquisarNome(string nome);
        IList<Veiculo> PesquisaTipo(Veiculo exemplo);
    }
}
