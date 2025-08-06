namespace Domain.Models
{
    public class ComandaProduto
    {
        public int Id { get; set; }

        public int ComandaId { get; set; }
        public virtual Comanda Comanda { get; set; }
        
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
