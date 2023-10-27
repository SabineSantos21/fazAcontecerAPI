using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazAcontecerAPI.Models
{
    public class Aperitivo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("preco_unidade")]
        public decimal Preco_unidade { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("idCategoria")]
        public int IdCategoria { get; set; }

        [JsonPropertyName("idEvento")]
        public int IdEvento { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime Data_criacao { get; set; }

        [JsonPropertyName("data_modificacao")]
        public DateTime Data_modificacao { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }

        [JsonPropertyName("check")]
        public bool Check { get; set; }
    }

    public class NovoAperitivo
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("preco_unidade")]
        public decimal Preco_unidade { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("idCategoria")]
        public int IdCategoria { get; set; }

        [JsonPropertyName("idEvento")]
        public int IdEvento { get; set; }
    }

    public class AtualizarAperitivo
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("preco_unidade")]
        public decimal Preco_unidade { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("idCategoria")]
        public int IdCategoria { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }

        [JsonPropertyName("check")]
        public bool Check { get; set; }
    }
}
