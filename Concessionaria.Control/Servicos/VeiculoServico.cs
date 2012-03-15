using System.Collections.Generic;
using Concessionaria.Control.Entidades;
using Concessionaria.Control.Repositorios;

namespace Concessionaria.Control.Servicos
{
    public interface IVeiculoServico
    {
        Veiculo PesquisarUm(int id);
        IList<Veiculo> PesquisarTodos();
        IList<Veiculo> PesquisarNome(string nome);
        IList<Veiculo> PesquisarTipo(Veiculo exemplo);
    }

    public class VeiculoServico:IVeiculoServico
    {
        private readonly IVeiculoDAO _veiculoDao;

        public VeiculoServico(IVeiculoDAO veiculoDao)
        {
            _veiculoDao = veiculoDao;
        }


        public Veiculo PesquisarUm(int id)
        {
            return _veiculoDao.GetOne(id);
        }

        public IList<Veiculo> PesquisarTodos()
        {
            return _veiculoDao.GetAll();
        }

        public IList<Veiculo> PesquisarNome(string nome)
        {
            return _veiculoDao.PesquisarNome(nome);
        }

        public IList<Veiculo> PesquisarTipo(Veiculo exemplo)
        {
            return _veiculoDao.PesquisaTipo(exemplo);
        }
    }
}
