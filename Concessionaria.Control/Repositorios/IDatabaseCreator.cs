using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concessionaria.Control.Repositorios
{
    public interface IDatabaseCreator
    {
        void CriarDB();
        void InserirDadosTeste(IVeiculoDAO veiculoDao, ILojaDAO lojaDao);
    }
}
