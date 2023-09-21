using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazAcontecerAPI.Models
{
    public class Evento
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("data_evento")]
        public DateTime DataEvento { get; set; }

        [JsonPropertyName("horario")]
        public DateTime Horario { get; set; }
        
        [JsonPropertyName("local_evento")]
        public string? LocalEvento { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }

        [JsonPropertyName("orcamento")]
        public decimal Orcamento { get; set; }

        [JsonPropertyName("data_final_confirmacao_convite")]
        public DateTime DataFinalConfirmacaoConvite { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonPropertyName("data_modificacao")]
        public DateTime DataModificacao { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }
}
