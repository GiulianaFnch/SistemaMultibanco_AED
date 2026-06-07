namespace Multibanco.Models
{
    public class Movimento
    {
        public int IdMovimento { get; set; }
        public int IdConta { get; set; }
        public DateTime Data { get; set; }
        public string? Tipo { get; set; }
        public decimal Valor { get; set; }
        public string? Descricao { get; set; }
    }
}