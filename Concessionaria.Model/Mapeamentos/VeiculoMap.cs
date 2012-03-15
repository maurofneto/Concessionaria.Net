using FluentNHibernate.Mapping;
using Concessionaria.Control.Entidades;

namespace Concessionaria.Model.Mapeamentos
{
    public class VeiculoMap : ClassMap<Veiculo>
    {
        public VeiculoMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Ano);
            Map(x => x.Cor);
            Map(x => x.Marca);
            Map(x => x.Modelo);
            Map(x => x.Nome);
            References(x => x.Loja);
        }
    }
}
