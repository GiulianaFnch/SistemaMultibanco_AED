namespace Multibanco.DataAccessLayer
{
    // Guarda as associações do MBWay: que número de telemóvel está ligado a que conta.
    // Tal como o AccountRepository, mantém os dados numa coleção "static" (em memória),
    // partilhada por toda a aplicação. A Giuliana poderá mais tarde passar isto para
    // uma tabela em SQL Server sem alterar a forma como o resto do código a usa.
    public class MBWayRepository
    {
        // Chave = número de telemóvel, Valor = número da conta associada.
        private static Dictionary<string, string> associacoes = new Dictionary<string, string>();

        // Indica se este telemóvel já está associado a alguma conta.
        public bool TelefoneJaUsado(string telefone)
        {
            return associacoes.ContainsKey(telefone);
        }

        // Indica se esta conta já tem o MBWay ativo (algum telemóvel associado).
        public bool ContaTemMBWay(string accountNumber)
        {
            return associacoes.ContainsValue(accountNumber);
        }

        // Devolve o telemóvel associado a uma conta (ou null se não tiver MBWay).
        public string? GetTelefoneDaConta(string accountNumber)
        {
            foreach (var par in associacoes)
            {
                if (par.Value == accountNumber)
                    return par.Key;
            }
            return null;
        }

        // Devolve o número de conta associado a um telemóvel (ou null se não existir).
        public string? GetContaPorTelefone(string telefone)
        {
            return associacoes.TryGetValue(telefone, out string? conta) ? conta : null;
        }

        // Cria a associação telemóvel -> conta.
        public void Associar(string telefone, string accountNumber)
        {
            associacoes[telefone] = accountNumber;
        }
    }
}
