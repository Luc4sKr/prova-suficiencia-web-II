using Domain.Models;
using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class UpdateComandaRequest
    {
        [JsonPropertyName("idUsuario")]
        public int? IdUsuario { get; set; }

        [JsonPropertyName("nomeUsuario")]
        public string? NomeUsuario { get; set; }

        [JsonPropertyName("telefoneUsuario")]
        public string? TelefoneUsuario { get; set; }

        [JsonPropertyName("produtos")]
        public List<UpdateProdutoRequest>? Produtos { get; set; }
    }

    public class UpdateProdutoRequest
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [JsonPropertyName("nome")]
        public required string Nome { get; set; }

        [JsonPropertyName("preco")]
        public required int Preco { get; set; }
    }
}
