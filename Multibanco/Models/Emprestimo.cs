namespace Multibanco.Models
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public int IdConta { get; set; }
        public decimal Montante { get; set; }
        public int PrazoMeses { get; set; }
        public decimal TaxaJuroAnual { get; set; }
        public decimal PrestacaoMensal { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Estado { get; set; } = "Aprovado";
    }
}
