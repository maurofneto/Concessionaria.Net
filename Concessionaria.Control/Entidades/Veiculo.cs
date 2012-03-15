namespace Concessionaria.Control.Entidades
{
    public class Veiculo
    {
        public virtual int Id { get; private set; }
        public virtual string Nome { get; set; }
        public virtual string Marca { get; set; }
        public virtual string Cor { get;set; }
        public virtual int Ano { get; set; }
        public virtual int Modelo { get; set; }
        public virtual Loja Loja { get; set; }

        public Veiculo(){}
        public Veiculo(string nome = "", string marca = "", string cor = "", int ano = 2012, int modelo = 2012, Loja loja = null)
        {
            Nome = nome;
            Marca = marca;
            Cor = cor;
            Ano = ano;
            Modelo = modelo;
            Loja = loja;
        }

        //public virtual IList<Loja> Lojas { get; set; }

        //public virtual void AdicionarLoja(Loja loja)
        //{
        //    if (Lojas == null)
        //    {
        //        Lojas = new List<Loja>();
        //    }
        //    Lojas.Add(loja);
        //}
    }
}
