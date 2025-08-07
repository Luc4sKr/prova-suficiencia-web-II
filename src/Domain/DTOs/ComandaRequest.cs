using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class ComandaRequest
    {
        [Required]
        public int IdUsuario { get; set; }
        
        [Required]
        public string NomeUsuario { get; set; }
        
        [Required]
        public string TelefoneUsuario { get; set; }

        [Required]
        public List<ProdutoRequest> Produtos  { get; set; }
    }

    public class ProdutoRequest
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public int Preco { get; set; }
    }
}
