using System;
using System.Web.UI;
using Castle.Windsor;
using Concessionaria.Control.Entidades;
using Concessionaria.Control.Repositorios;
using Concessionaria.Control.Servicos;
using Concessionaria.Model.Helpers;
using Concessionaria.Model.Repositorios;
using NHibernate;

namespace Concessionaria.ajax
{
    public partial class inserirDadosTeste : Page
    {
        private IServicos _servicosDao;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            WindsorContainer container = Global.InicializarContainer();
            _servicosDao = container.Resolve<IServicos>();
            
            try
            {
                _servicosDao.InserirDadosTeste();
                Response.Write("Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}