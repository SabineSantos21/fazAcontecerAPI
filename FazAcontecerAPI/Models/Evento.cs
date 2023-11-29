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
        public DateTime Data_evento { get; set; }

        [JsonPropertyName("horario")]
        public DateTime Horario { get; set; }
        
        [JsonPropertyName("local_evento")]
        public string? Local_evento { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }

        [JsonPropertyName("orcamento")]
        public decimal Orcamento { get; set; }

        [JsonPropertyName("data_final_confirmacao_convite")]
        public DateTime Data_final_confirmacao_convite { get; set; }

        [JsonPropertyName("data_criacao")]
        public DateTime Data_criacao { get; set; }

        [JsonPropertyName("data_modificacao")]
        public DateTime Data_modificacao { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }

        [JsonPropertyName("id_usuario")]
        public int id_usuario { get; set; }
    }

    public class NovoEvento
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("data_evento")]
        public string Data_evento { get; set; }

        [JsonPropertyName("horario")]
        public string Horario { get; set; }

        [JsonPropertyName("local_evento")]
        public string? Local_evento { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }

        [JsonPropertyName("orcamento")]
        public decimal Orcamento { get; set; }

        [JsonPropertyName("id_usuario")]
        public int Id_usuario { get; set; }
    }

    public class AtualizarEvento
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("data_evento")]
        public string Data_evento { get; set; }

        [JsonPropertyName("horario")]
        public string Horario { get; set; }

        [JsonPropertyName("local_evento")]
        public string? Local_evento { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }

        [JsonPropertyName("orcamento")]
        public decimal Orcamento { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }

    public class RetornarExtratoEvento
    {
        [JsonPropertyName("saldo")]
        public decimal Saldo { get; set; }

        [JsonPropertyName("itens")]
        public List<ItemExtrato>? Itens { get; set; }
    }

    public class ItemExtrato
    {
        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("quantidade")]
        public int? Quantidade { get; set; }

        [JsonPropertyName("preco")]
        public decimal? Preco { get; set; }
    }
}
