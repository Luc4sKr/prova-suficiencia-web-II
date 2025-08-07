using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class ComandaResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Id { get; set; }

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }

        public List<ProdutoResponse> Produtos { get; set; }
    }

    public class ProdutoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
    }
}
