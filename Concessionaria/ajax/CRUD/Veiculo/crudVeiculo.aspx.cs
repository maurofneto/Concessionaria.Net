using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.Windsor;
using Concessionaria.Control.Repositorios;
using Concessionaria.Control.Servicos;

namespace Concessionaria.ajax.CRUD.Veiculo
{
    public partial class crudVeiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WindsorContainer container = Global.InicializarContainer();
            ILojaServico lojaServico = container.Resolve<ILojaServico>();
            IVeiculoServico veiculoServico = container.Resolve<IVeiculoServico>();
            IVeiculoDAO veiculoDao = container.Resolve<IVeiculoDAO>();

            string acao = Request["acao"];
            if (acao == "incluir")
            {
                Control.Entidades.Veiculo veiculoNovo = new Control.Entidades.Veiculo();
                veiculoNovo.Nome = Request.Form["Nome"];
                veiculoNovo.Marca = Request.Form["Marca"];
                veiculoNovo.Ano = Convert.ToInt32(Request.Form["Ano"]);
                veiculoNovo.Modelo = Convert.ToInt32(Request.Form["Modelo"]);
                veiculoNovo.Cor = Request.Form["Cor"];
                veiculoNovo.Loja = lojaServico.PesquisarUm(Convert.ToInt32(Request.Form["Loja"]));

                veiculoDao.SaveOrUpdateAndFlush(veiculoNovo);

                Response.Write("Dados incluídos com sucesso!");
            }
            else if (acao == "buscar")
            {
                Control.Entidades.Veiculo veiculo = veiculoServico.PesquisarUm(Convert.ToInt32(Request.Form["Id"]));
                if (veiculo == null)
                {
                    Response.Write("Veículo inexistente!");
                }
                else
                {
                    IList<Control.Entidades.Loja> lojas = lojaServico.PesquisarTodos();
                    Response.Write("<div id=\"formVeiculo\">");
                    Response.Write("<table>");
                        Response.Write("<tr>");
                            Response.Write("<td>Nome:</td>");
                            Response.Write("<td><input id=\"txtNome\" type=\"text\" Value=\"" + veiculo.Nome + "\" /></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                            Response.Write("<td>Marca:</td>");
                            Response.Write("<td><input id=\"txtMarca\" type=\"text\" Value=\"" + veiculo.Marca + "\" /></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                            Response.Write("<td>Ano:</td>");
                            Response.Write("<td><input id=\"txtAno\" type=\"text\" Value=\"" + veiculo.Ano + "\" /></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                            Response.Write("<td>Modelo:</td>");
                            Response.Write("<td><input id=\"txtModelo\" type=\"text\" Value=\"" + veiculo.Modelo + "\" /></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                            Response.Write("<td>Cor:</td>");
                            Response.Write("<td><input id=\"txtCor\" type=\"text\" Value=\"" + veiculo.Cor + "\" /></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                            Response.Write("<td>Loja:</td>");
                            Response.Write("<td>" +
                                            "<select id=\"cboLoja\">");
                                                foreach (Control.Entidades.Loja loja in lojas)
                                                {
                                                    Response.Write("<option value=\"" + loja.Id + "\" " +
                                                                   (veiculo.Loja == loja ? "selected" : "") +
                                                                   ">" + loja.Nome + "</option>");
                                                }
                            Response.Write("</select>" +
                                           "</td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                    Response.Write("<td><img src=\"../Content/save.png\" OnClick=\"salvarVeiculo(" + veiculo.Id +
                                   ");\" align=\"Top\" width=\"24\" height=\"24\" /></td>");
                        Response.Write("</tr>");
                    Response.Write("</table>");
                    Response.Write("</div>");
                    Response.Write("<div id=\"divResultadoEdit\"></div>");

                    /*
            <asp:TableCell runat="server" ColumnSpan="2" HorizontalAlign="Center">
                <img src="../Content/save.png" id="ImageButtonSalvar" align="Top" width="24" height="24" />
                <!-- <asp:ImageButton ID="ImageButtonSalvar" runat="server" 
                                ImageUrl="../Content/save.png" ImageAlign="Top" Width="24" Height="24" /> -->
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Content/cancel.png" id="ImageButtonCancelar" align="Top" width="24" height="24" />
                <!-- <asp:ImageButton ID="ImageButtonCancelar" runat="server" 
                                ImageUrl="../Content/cancel.png" ImageAlign="Top" Width="24" Height="24" /> -->
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div id="divResultado"></div>
                     */
                }
            }
            else if (acao == "excluir")
            {
                int id = Convert.ToInt32(Request.Form["Id"]);
                veiculoDao.Delete(id);
                Response.Write("Veículo excluído com sucesso!");
            }
            else if (acao == "salvar")
            {
                int id = Convert.ToInt32(Request.Form["Id"]);

                Control.Entidades.Veiculo veiculoNovo = new Control.Entidades.Veiculo();
                veiculoNovo = veiculoServico.PesquisarUm(id);
                if (veiculoNovo != null)
                {
                    veiculoNovo.Nome = Request.Form["Nome"];
                    veiculoNovo.Marca = Request.Form["Marca"];
                    veiculoNovo.Ano = Convert.ToInt32(Request.Form["Ano"]);
                    veiculoNovo.Modelo = Convert.ToInt32(Request.Form["Modelo"]);
                    veiculoNovo.Cor = Request.Form["Cor"];
                    veiculoNovo.Loja = lojaServico.PesquisarUm(Convert.ToInt32(Request.Form["Loja"]));

                    veiculoDao.SaveOrUpdateAndFlush(veiculoNovo);

                    Response.Write("Dados alterados com sucesso!");
                }
                else
                {
                    Response.Write("Veículo inesistente!");
                }
            }
        }
    }
}