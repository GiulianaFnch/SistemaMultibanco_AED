namespace Multibanco.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int IdBanco { get; set; }
        public string? Nome { get; set; }
        public string? NIF { get; set; }
    }
}