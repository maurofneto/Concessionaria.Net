using System;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Concessionaria.Control.Repositorios;
using Concessionaria.Control.Servicos;
using Concessionaria.Model.Helpers;
using Concessionaria.Model.Repositorios;

namespace Concessionaria
{
    public class Global : HttpApplication
    {
        private IServicos _servicos;

        private void Application_Start(object sender, EventArgs e)
        {
            WindsorContainer container = InicializarContainer();

            _servicos = container.Resolve<IServicos>();
            _servicos.CriarDB();
            _servicos.InserirDadosTeste();
        }

        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        private void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        private void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }

        public static WindsorContainer InicializarContainer()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IDatabaseCreator>().ImplementedBy<DatabaseCreator>());
            container.Register(Component.For<ILojaDAO>().ImplementedBy<LojaDAO>());
            container.Register(Component.For<ILojaServico>().ImplementedBy<LojaServico>());
            container.Register(Component.For<IServicos>().ImplementedBy<Servicos>());
            container.Register(Component.For<IVeiculoDAO>().ImplementedBy<VeiculoDAO>());
            container.Register(Component.For<IVeiculoServico>().ImplementedBy<VeiculoServico>());

            var sessionFactoryProvider = new SessionFactoryProvider();
            container.Register(
                Component.For<SessionProvider>().
                    LifeStyle.Singleton.
                    Instance(new SessionProvider(sessionFactoryProvider)));
            return container;
        }
    }
}