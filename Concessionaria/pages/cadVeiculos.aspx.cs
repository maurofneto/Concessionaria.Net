using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.Windsor;
using Concessionaria.Control.Entidades;
using Concessionaria.Control.Servicos;

namespace Concessionaria.pages
{
    public partial class cadVeiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WindsorContainer container = Global.InicializarContainer();
            ILojaServico lojaServico = container.Resolve<ILojaServico>();
            IList<Loja> lojas = lojaServico.PesquisarTodos();

            foreach (Loja loja in lojas)
            {
                DropDownListLoja.Items.Add(new ListItem(loja.Nome,loja.Id.ToString()));
            }
        }
    }
}