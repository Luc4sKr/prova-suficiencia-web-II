namespace Domain.DTOs
{
    public class ComandaRequest
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }

        public List<ProdutoRequest> Produtos  { get; set; }
    }

    public class ProdutoRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
    }
}
