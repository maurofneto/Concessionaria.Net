using Concessionaria.Control.Entidades;
using FluentNHibernate.Mapping;

namespace Concessionaria.Model.Mapeamentos
{
    public class LojaMap:ClassMap<Loja>
    {
        public LojaMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Nome);
            HasMany(x => x.Veiculos);
        }
    }
}
