namespace PDV.Net.Domain.Entity
{
    public class Produto : BaseEntity
    {

        public string Nome { get; set; }
        public double Valor { get; set; }
        public double Custo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
