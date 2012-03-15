using Concessionaria.Control.Entidades;
using Concessionaria.Control.Repositorios;

namespace Concessionaria.Model.Helpers
{
    public class DatabaseCreator:IDatabaseCreator
    {
        public void CriarDB()
        {
            var sessionFactoryProvider = new SessionFactoryProvider();
            var sessionProvider = new SessionProvider(sessionFactoryProvider);
            sessionProvider.GetCurrentSession();
            sessionFactoryProvider.CriarDB();
        }

        public void InserirDadosTeste(IVeiculoDAO veiculoDao, ILojaDAO lojaDao)
        {
            var provider = new SessionFactoryProvider();
            var sessionProvider = new SessionProvider(provider);
            var sessaoAtual = sessionProvider.GetCurrentSession();

            var loja = new Loja("Loja Jac " + lojaDao.GetAll().Count);
            lojaDao.SaveOrUpdateAndFlush(loja);
            
            var veiculo = new Veiculo("J6 Turin", "Jac Motors", "Red", 2011, 2012, loja);
            veiculoDao.SaveOrUpdateAndFlush(veiculo);
            loja.AdicionarVeiculos(veiculo);

            veiculo = new Veiculo("J7 Turin", "Jac Motors", "Black", 2011, 2012, loja);
            veiculoDao.SaveOrUpdateAndFlush(veiculo);
            loja.AdicionarVeiculos(veiculo);

            veiculo = new Veiculo("J8 Turin", "Jac Motors", "Blue", 2011, 2012, loja);
            veiculoDao.SaveOrUpdateAndFlush(veiculo);
            loja.AdicionarVeiculos(veiculo);

            veiculo = new Veiculo("J9 Turin", "Jac Motors", "Yellow", 2011, 2012, loja);
            veiculoDao.SaveOrUpdateAndFlush(veiculo);
            loja.AdicionarVeiculos(veiculo);
            

            lojaDao.SaveOrUpdateAndFlush(loja);
        }
    }
}
