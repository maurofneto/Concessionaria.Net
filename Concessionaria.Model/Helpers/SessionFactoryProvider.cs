using System;
using Concessionaria.Model.Mapeamentos;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Concessionaria.Model.Helpers
{
    public class SessionFactoryProvider : IDisposable
    {
        private FluentConfiguration _fluentConfiguration;
        private ISessionFactory _sessionFactory;

        #region IDisposable Members

        public void Dispose()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Dispose();
            }
        }

        #endregion

        public ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                _fluentConfiguration = Fluently.Configure()
                                        .Database(MsSqlConfiguration.MsSql2008.ShowSql()
                                        .ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString")))
                                        //.Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Veiculo>(new AppAutomappingCfg())));
                                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<VeiculoMap>());
                                        //.Conventions.Setup(GetConventions()));

                _sessionFactory = _fluentConfiguration.BuildSessionFactory();
            }

            return _sessionFactory;
        }

        public void CriarDB()
        {
            if (_fluentConfiguration != null)
            {
                var sessionSource = new SessionSource(_fluentConfiguration);
                ISession session = sessionSource.CreateSession();
                sessionSource.BuildSchema(session);
            }
        }
    }

    public class AppAutomappingCfg : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace.StartsWith("Concessionaria.Control.Entidades");
        }
    }
}