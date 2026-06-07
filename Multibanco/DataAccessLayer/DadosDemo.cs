using Multibanco.Models;

namespace Multibanco.DataAccessLayer
{
    // Dados de exemplo do Elemento 3 — APENAS para demonstração.
    //
    // O repositório guarda os movimentos numa lista "static", por isso basta
    // criar um AccountRepository normal e registar alguns movimentos: eles ficam
    // visíveis para toda a aplicação. Assim conseguimos mostrar o extrato e a
    // abertura automática no login logo no arranque, sem ter de alterar o
    // ficheiro AccountRepository.cs (que a Giuliana vai ligar ao SQL Server).
    //
    // Quando a base de dados real estiver ligada, esta classe pode ser removida
    // ou simplesmente não chamada.
    public static class DadosDemo
    {
        private static bool _jaCarregado = false;

        public static void CarregarMovimentosExemplo()
        {
            if (_jaCarregado) return; // garante que só corre uma vez por execução
            _jaCarregado = true;

            var repo = new AccountRepository(); // partilha a mesma lista estática de movimentos

            // Conta 1 — João Silva
            repo.RegistarMovimento(new Movimento { IdConta = 1, Data = DateTime.Now.AddDays(-25), Tipo = "Depósito",      Valor =  750.00m, Descricao = "Depósito em numerário" });
            repo.RegistarMovimento(new Movimento { IdConta = 1, Data = DateTime.Now.AddDays(-18), Tipo = "Levantamento",  Valor = -120.00m, Descricao = "Levantamento em ATM" });
            repo.RegistarMovimento(new Movimento { IdConta = 1, Data = DateTime.Now.AddDays(-9),  Tipo = "Pagamento",     Valor =  -45.30m, Descricao = "Pagamento Água - Ref: 123456" });
            repo.RegistarMovimento(new Movimento { IdConta = 1, Data = DateTime.Now.AddDays(-2),  Tipo = "Transferência Recebida", Valor = 200.00m, Descricao = "Transferência de conta 987654321" });

            // Conta 2 — Maria Santos
            repo.RegistarMovimento(new Movimento { IdConta = 2, Data = DateTime.Now.AddDays(-14), Tipo = "Depósito",      Valor =  300.00m, Descricao = "Depósito em numerário" });
            repo.RegistarMovimento(new Movimento { IdConta = 2, Data = DateTime.Now.AddDays(-5),  Tipo = "Levantamento",  Valor =  -80.00m, Descricao = "Levantamento em ATM" });

            // Conta 3 — Pedro Oliveira
            repo.RegistarMovimento(new Movimento { IdConta = 3, Data = DateTime.Now.AddDays(-20), Tipo = "Pagamento",     Valor = -130.75m, Descricao = "Pagamento Luz - Ref: 998877" });
            repo.RegistarMovimento(new Movimento { IdConta = 3, Data = DateTime.Now.AddDays(-1),  Tipo = "Depósito",      Valor =  1000.00m, Descricao = "Depósito em numerário" });
        }
    }
}
