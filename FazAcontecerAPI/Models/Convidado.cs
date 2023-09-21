using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazAcontecerAPI.Models
{
    public class Convidado
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("telefone")]
        public string? Telefone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
        
        [JsonPropertyName("idEvento")]
        public int IdEvento { get; set; }

        [JsonPropertyName("aceitou_convite")]
        public bool AceitouConvite { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("data_modificacao")]
        public DateTime DataModificacao { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }

    public class NovoConvidado
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("telefone")]
        public string? Telefone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }

    public class AtualizarConvidado
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("telefone")]
        public string? Telefone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }
}
