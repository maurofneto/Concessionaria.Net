using Concessionaria.Control.Repositorios;

namespace Concessionaria.Control.Servicos
{
    public interface IServicos
    {
        void CriarDB();
        void InserirDadosTeste();
    }

    public class Servicos : IServicos
    {
        private readonly IDatabaseCreator _databaseCreator;
        private readonly ILojaDAO _lojaDao;
        private readonly IVeiculoDAO _veiculoDao;

        public Servicos(IVeiculoDAO veiculoDao, ILojaDAO lojaDao,
                        IDatabaseCreator databaseCreator)
        {
            _veiculoDao = veiculoDao;
            _lojaDao = lojaDao;
            _databaseCreator = databaseCreator;
        }

        #region IServicosDAO Members

        public void CriarDB()
        {
            _databaseCreator.CriarDB();
        }

        public void InserirDadosTeste()
        {
            _databaseCreator.InserirDadosTeste(_veiculoDao, _lojaDao);
        }

        #endregion
    }
}