using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.Components.DictionaryAdapter;
using Castle.Windsor;
using Concessionaria.Control.Entidades;
using Concessionaria.Control.Repositorios;
using Concessionaria.Control.Servicos;
using Concessionaria.Model.Helpers;
using Concessionaria.Model.Repositorios;

namespace Concessionaria
{
    public partial class visualisar : System.Web.UI.Page
    {
        private ILojaServico _lojaServico;
        private IVeiculoServico _veiculoServico;

        protected void Page_Load(object sender, EventArgs e)
        {
            WindsorContainer container = Global.InicializarContainer();
            _lojaServico = container.Resolve<ILojaServico>();
            _veiculoServico = container.Resolve<IVeiculoServico>();
            IList<Loja> lojas = new List<Loja>();

            if (DropDownListLoja.Items.Count == 0)
            {
                DropDownListLoja.Items.Add(new ListItem("", "-1"));
                lojas = _lojaServico.PesquisarTodos();
                foreach (Loja loja in lojas)
                {
                    DropDownListLoja.Items.Add(new ListItem(loja.Nome, loja.Id.ToString()));
                }
            }

            PreencherGrade(lojas);
        }

        protected void DropDownListLoja_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            IList<Loja> lojas = new List<Loja>();
            int valor = Convert.ToInt32(DropDownListLoja.SelectedValue);
            if (valor>0)
            {
                lojas.Add(_lojaServico.PesquisarUm(valor));
            }else
            {
                lojas = _lojaServico.PesquisarTodos();
            }
            PreencherGrade(lojas);
        }

        private void PreencherGrade(IList<Loja> lojas)
        {
            tblDados.Rows.Clear();
            foreach (Loja loja in lojas)
            {
                IList<Veiculo> veiculos = loja.Veiculos;
                if (veiculos.Count > 0)
                {
                    tblDados.Rows.Add(new TableRow());
                    var rowLoja = tblDados.Rows[tblDados.Rows.Count - 1];

                    rowLoja.Cells.Add(new TableCell());
                    var cellLoja = rowLoja.Cells[0];
                    cellLoja.Text = loja.Id.ToString();

                    rowLoja.Cells.Add(new TableCell());
                    cellLoja = rowLoja.Cells[1];
                    cellLoja.Text = loja.Nome;
                    cellLoja.ColumnSpan = 7;

                    foreach (Veiculo veiculo in veiculos)
                    {
                        TableRow linha;
                        Color cor = Color.White;

                        cor = (tblDados.Rows.Count - 1) % 2 == 0 ? Color.FromArgb(255, 135, 206, 250) : Color.FromArgb(255, 100, 149, 237);

                        //135 206 250
                        //100 149 237

                        if (TextBoxNome.Text.Length > 0)
                        {
                            if (veiculo.Nome.Contains(TextBoxNome.Text))
                            {
                                linha = new TableRow();
                                //linha.BackColor = Color.FromArgb(255, 255, 204, 0);
                                linha.BackColor = cor;
                                linha.ForeColor = Color.Black;

                                tblDados.Rows.Add(linha);
                                var rowVei = tblDados.Rows[tblDados.Rows.Count - 1];

                                rowVei.Cells.Add(new TableCell());
                                var cellVei = rowVei.Cells[0];
                                cellVei.Text = veiculo.Id.ToString();

                                rowVei.Cells.Add(new TableCell());
                                cellVei = rowVei.Cells[1];
                                cellVei.Text = veiculo.Nome;

                                rowVei.Cells.Add(new TableCell());
                                cellVei = rowVei.Cells[2];
                                cellVei.Text = veiculo.Marca;

                                rowVei.Cells.Add(new TableCell());
                                cellVei = rowVei.Cells[3];
                                cellVei.Text = veiculo.Ano.ToString();

                                rowVei.Cells.Add(new TableCell());
                                cellVei = rowVei.Cells[4];
                                cellVei.Text = veiculo.Modelo.ToString();

                                rowVei.Cells.Add(new TableCell());
                                cellVei = rowVei.Cells[5];
                                cellVei.Text = veiculo.Cor;
                                cellVei.BackColor = Color.FromName(veiculo.Cor);

                                rowVei.Cells.Add(new TableCell());
                                cellVei = rowVei.Cells[6];
                                cellVei.Text =
                                    "<img src=\"../Content/edit.png\" width=\"16\" height=\"16\" onclick=\"buscarVeiculo(" +
                                    veiculo.Id + ")\" />";

                                rowVei.Cells.Add(new TableCell());
                                cellVei = rowVei.Cells[7];
                                cellVei.Text =
                                    "<img src=\"../Content/del.png\" width=\"16\" height=\"16\" onclick=\"excluirVeiculo(" +
                                    veiculo.Id + ")\" />";
                            }
                        }
                        else
                        {
                            linha = new TableRow();
                            //linha.BackColor = Color.FromArgb(255, 204, 204, 204);
                            linha.BackColor = cor;
                            linha.ForeColor = Color.Black;

                            tblDados.Rows.Add(linha);
                            var rowVei = tblDados.Rows[tblDados.Rows.Count - 1];

                            rowVei.Cells.Add(new TableCell());
                            var cellVei = rowVei.Cells[0];
                            cellVei.Text = veiculo.Id.ToString();

                            rowVei.Cells.Add(new TableCell());
                            cellVei = rowVei.Cells[1];
                            cellVei.Text = veiculo.Nome;

                            rowVei.Cells.Add(new TableCell());
                            cellVei = rowVei.Cells[2];
                            cellVei.Text = veiculo.Marca;

                            rowVei.Cells.Add(new TableCell());
                            cellVei = rowVei.Cells[3];
                            cellVei.Text = veiculo.Ano.ToString();

                            rowVei.Cells.Add(new TableCell());
                            cellVei = rowVei.Cells[4];
                            cellVei.Text = veiculo.Modelo.ToString();

                            rowVei.Cells.Add(new TableCell());
                            cellVei = rowVei.Cells[5];
                            cellVei.Text = veiculo.Cor;
                            cellVei.BackColor = Color.FromName(veiculo.Cor);

                            rowVei.Cells.Add(new TableCell());
                            cellVei = rowVei.Cells[6];
                            cellVei.Text =
                                "<img src=\"../Content/edit.png\" width=\"16\" height=\"16\" onclick=\"buscarVeiculo(" +
                                veiculo.Id + ")\" />";

                            rowVei.Cells.Add(new TableCell());
                            cellVei = rowVei.Cells[7];
                            cellVei.Text =
                                "<img src=\"../Content/del.png\" width=\"16\" height=\"16\" onclick=\"excluirVeiculo(" +
                                veiculo.Id + ")\" />";
                        }
                    }
                }
            }
        }

        protected void TextBoxNome_OnTextChanged(object sender, EventArgs e)
        {
            IList<Loja> lojas = _lojaServico.PesquisarTodos();
            PreencherGrade(lojas);
            //foreach (Loja loja in lojas)
            //{
            //    Veiculo exemplo = new Veiculo();
            //    exemplo.Nome = TextBoxNome.Text;
            //    //exemplo.Loja = loja;

            //    IList<Veiculo> veiculos = _veiculoServico.PesquisarTipo(exemplo);
            //}
        }
    }
}