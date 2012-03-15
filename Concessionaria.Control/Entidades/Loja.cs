using System.Collections.Generic;

namespace Concessionaria.Control.Entidades
{
    public class Loja
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual IList<Veiculo> Veiculos { get; set; }

        public Loja()
        {
            
        }
        public Loja(string nome)
        {
            Nome = nome;
            if (Veiculos == null)
            {
                Veiculos = new List<Veiculo>();
            }
        }

        public virtual void AdicionarVeiculos(Veiculo veiculo)
        {   
            veiculo.Loja = this;
            Veiculos.Add(veiculo);
        }
    }
}
