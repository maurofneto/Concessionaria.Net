using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Castle.Windsor;
using Concessionaria.Control.Entidades;
using Concessionaria.Control.Servicos;

namespace Concessionaria.ajax
{
    public partial class geraXmlDados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WindsorContainer container = Global.InicializarContainer();
            ILojaServico lojaServico = container.Resolve<ILojaServico>();
            IVeiculoServico veiculoServico = container.Resolve<IVeiculoServico>();

            XmlDocument doc = new XmlDocument();
            XmlNode raiz = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(raiz);

            string filtroNome = Request.Form["Nome"];
            int filtroLoja = Convert.ToInt32(Request.Form["Loja"]);

            IList<Loja> lojas = new List<Loja>();
            IList<Veiculo> veiculos = new List<Veiculo>();

            if (filtroLoja != null && filtroLoja > 0)
            {
                lojas.Add(lojaServico.PesquisarUm(filtroLoja));
            }
            else
            {
                lojas = lojaServico.PesquisarTodos();
            }

            XmlNode nodeLojas = doc.CreateElement("Lojas");
            foreach (Loja loja in lojas)
            {
                XmlNode nodeLoja = doc.CreateElement("Loja");
                XmlAttribute attrIdLoja = doc.CreateAttribute("id");
                nodeLoja.InnerText = loja.Nome;
                attrIdLoja.Value = loja.Id.ToString();
                nodeLoja.Attributes.Append(attrIdLoja);

                nodeLojas.AppendChild(nodeLoja);

                veiculos = loja.Veiculos;
                XmlNode nodeVeiculos = doc.CreateElement("veiculos");
                foreach (Veiculo veiculo in veiculos)
                {
                    if (!string.IsNullOrEmpty(filtroNome))
                    {
                        if (veiculo.Nome.Contains(filtroNome))
                        {
                            XmlNode nodeVeiculo = doc.CreateElement("Veiculo");
                            XmlAttribute attrIdVeiculo = doc.CreateAttribute("id");
                            attrIdVeiculo.Value = veiculo.Id.ToString();
                            nodeVeiculo.Attributes.Append(attrIdVeiculo);

                            XmlNode propriedade;
                            string[] nomes = {
                                                 "Nome",
                                                 "Marca",
                                                 "Ano",
                                                 "Modelo",
                                                 "Cor"
                                             };
                            string[] valores = {
                                                   veiculo.Nome,
                                                   veiculo.Marca,
                                                   veiculo.Ano.ToString(),
                                                   veiculo.Modelo.ToString(),
                                                   veiculo.Cor
                                               };

                            for (int i = 0; i < nomes.Length; i++)
                            {
                                propriedade = doc.CreateElement(nomes[i]);
                                propriedade.InnerText = valores[i];
                                nodeVeiculo.AppendChild(propriedade);
                            }

                            nodeVeiculos.AppendChild(nodeVeiculo);
                        }
                    }
                    else
                    {
                        XmlNode nodeVeiculo = doc.CreateElement("Veiculo");
                        XmlAttribute attrIdVeiculo = doc.CreateAttribute("id");
                        attrIdVeiculo.Value = veiculo.Id.ToString();
                        nodeVeiculo.Attributes.Append(attrIdVeiculo);

                        XmlNode propriedade;
                        string[] nomes = {
                                                 "Nome",
                                                 "Marca",
                                                 "Ano",
                                                 "Modelo",
                                                 "Cor"
                                             };
                        string[] valores = {
                                                   veiculo.Nome,
                                                   veiculo.Marca,
                                                   veiculo.Ano.ToString(),
                                                   veiculo.Modelo.ToString(),
                                                   veiculo.Cor
                                               };

                        for (int i = 0; i < nomes.Length; i++)
                        {
                            propriedade = doc.CreateElement(nomes[i]);
                            propriedade.InnerText = valores[i];
                            nodeVeiculo.AppendChild(propriedade);
                        }

                        nodeVeiculos.AppendChild(nodeVeiculo);
                    }
                }
                nodeLoja.AppendChild(nodeVeiculos);
            }
            
            doc.AppendChild(nodeLojas);
            

            Response.Write(doc.InnerXml);
        }
    }
}