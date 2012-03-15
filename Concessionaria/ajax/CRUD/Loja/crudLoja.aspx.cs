using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.Windsor;
using Concessionaria.Control.Repositorios;

namespace Concessionaria.ajax.CRUD.Loja
{
    public partial class crudLoja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["acao"] == "incluir")
            {
                WindsorContainer container = Global.InicializarContainer();
                ILojaDAO lojaDao = container.Resolve<ILojaDAO>();

                Control.Entidades.Loja lojaNova = new Control.Entidades.Loja();
                lojaNova.Nome = Request.Form["Nome"];

                lojaDao.SaveOrUpdateAndFlush(lojaNova);

                Response.Write("Dados incluídos com sucesso!");
            }
        }
    }
}