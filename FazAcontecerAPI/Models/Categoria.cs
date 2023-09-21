using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazAcontecerAPI.Models
{
    public class Categoria
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("tipo_categoria")]
        public int TipoCategoria { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("data_modificacao")]
        public DateTime DataModificacao { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }

    public class NovaCategoria
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("tipo_categoria")]
        public int TipoCategoria { get; set; }
    }

    public class AtualizarCategoria
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("tipo_categoria")]
        public int TipoCategoria { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }
}
