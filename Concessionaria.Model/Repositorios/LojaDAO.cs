using Concessionaria.Control.Entidades;
using Concessionaria.Control.Repositorios;
using Concessionaria.Model.Helpers;

namespace Concessionaria.Model.Repositorios
{
    public class LojaDAO:DAO<Loja>,ILojaDAO
    {
        public LojaDAO(SessionProvider sessionProvider) : base(sessionProvider)
        {

        }
    }
}
