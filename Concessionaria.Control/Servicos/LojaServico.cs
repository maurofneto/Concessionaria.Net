using System.Collections.Generic;
using Concessionaria.Control.Entidades;
using Concessionaria.Control.Repositorios;

namespace Concessionaria.Control.Servicos
{
    public interface ILojaServico
    {
        Loja PesquisarUm(int id);
        IList<Loja> PesquisarTodos();
    }

    public class LojaServico:ILojaServico
    {
        private readonly ILojaDAO _lojaDao;

        public LojaServico(ILojaDAO lojaDao)
        {
            _lojaDao = lojaDao;
        }


        public Loja PesquisarUm(int id)
        {
            return _lojaDao.GetOne(id);
        }

        public IList<Loja> PesquisarTodos()
        {
            return _lojaDao.GetAll();
        }
    }
}
