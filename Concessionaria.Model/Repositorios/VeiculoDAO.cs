using System.Collections.Generic;
using Concessionaria.Control.Entidades;
using Concessionaria.Control.Repositorios;
using Concessionaria.Model.Helpers;
using NHibernate;
using NHibernate.Criterion;

namespace Concessionaria.Model.Repositorios
{
    public class VeiculoDAO:DAO<Veiculo>,IVeiculoDAO
    {
        public VeiculoDAO(SessionProvider sessionProvider) : base(sessionProvider)
        {

        }

        public IList<Veiculo> PesquisarNome(string nome)
        {
            ICriteria criteria =
                Session.CreateCriteria(typeof (Veiculo)).Add(Expression.InsensitiveLike("Nome", "%" + nome + "%"));
            return criteria.List<Veiculo>();
        }

        public IList<Veiculo> PesquisaTipo(Veiculo exemplo)
        {
            ICriteria criteria =
                Session.CreateCriteria(typeof(Veiculo)).Add(
                            Example.Create(exemplo)
                            .EnableLike(MatchMode.Anywhere)
                            .IgnoreCase());
            return criteria.List<Veiculo>();
        }
    }
}
