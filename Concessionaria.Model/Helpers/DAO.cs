using System.Collections.Generic;
using Concessionaria.Control.Repositorios;
using Concessionaria.Model.Helpers;
using NHibernate;

namespace Concessionaria.Model.Repositorios
{
    public class DAO<T> : IRepositorio<T>
    {
        private readonly SessionProvider _sessionProvider;

        public DAO(SessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        protected ISession Session
        {
            get { return _sessionProvider.GetCurrentSession(); }
        }

        #region IRepositorio<T> Members

        public void SaveOrUpdateAndFlush(T entidade)
        {
            Session.SaveOrUpdate(entidade);
            Session.Flush();
        }

        public T GetOne(int id)
        {
            return Session.Load<T>(id);
        }

        public void Delete(int id)
        {
            T entidade = GetOne(id);
            Delete(entidade);
        }

        public void Delete(T entidade)
        {
            Session.Delete(entidade);
            Session.Flush();
        }

        public IList<T> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria(typeof (T));
            return criteria.List<T>();
        }

        #endregion
    }
}