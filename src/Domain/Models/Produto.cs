namespace Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }

        public virtual List<ComandaProduto> ComandasProdutos { get; set; }
    }
}
