using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazAcontecerAPI.Models
{
    public class Decoracao
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("preco_unidade")]
        public decimal PrecoUnidade { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("idCategoria")]
        public int IdCategoria { get; set; }

        [JsonPropertyName("idEvento")]
        public int IdEvento { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("data_modificacao")]
        public DateTime DataModificacao { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }
}
