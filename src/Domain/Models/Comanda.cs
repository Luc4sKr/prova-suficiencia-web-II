namespace Domain.Models
{
    public class Comanda
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }

        public virtual List<ComandaProduto> ComandasProdutos { get; set; }
    }
}
