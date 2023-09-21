using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazAcontecerAPI.Models
{
    public class Usuario
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
        
        [JsonPropertyName("senha")]
        public string? Senha { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("data_modificacao")]
        public DateTime DataModificacao { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }

    public class NovoUsuario
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("senha")]
        public string? Senha { get; set; }
    }

    public class AtualizarUsuario
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("senha")]
        public string? Senha { get; set; }
    }
}
