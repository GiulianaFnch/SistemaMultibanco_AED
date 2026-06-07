using Multibanco.Models;
using Multibanco.DataAccessLayer;

namespace Multibanco.BusinessLogicLayer
{
    // Regras de negócio do MBWay (Elemento 3, funcionalidade extra).
    // Trata de duas coisas: ativar o MBWay (associar um telemóvel a uma conta)
    // e enviar dinheiro de uma conta para o telemóvel de outra pessoa.
    //
    // Usa o AccountRepository para mexer nos saldos/movimentos e o MBWayRepository
    // para as associações telemóvel <-> conta. Como ambos guardam os dados em
    // coleções "static", uma instância nova partilha sempre os mesmos dados.
    public class MBWayService
    {
        private readonly AccountRepository _accountRepository = new AccountRepository();
        private readonly MBWayRepository _mbwayRepository = new MBWayRepository();

        // A conta indicada tem o MBWay ativo?
        public bool TemMBWayAtivo(string accountNumber)
        {
            return _mbwayRepository.ContaTemMBWay(accountNumber);
        }

        // Telemóvel associado a uma conta (null se ainda não tiver MBWay).
        public string? TelefoneAssociado(string accountNumber)
        {
            return _mbwayRepository.GetTelefoneDaConta(accountNumber);
        }

        // Ativa o MBWay associando um número de telemóvel à conta.
        public bool AtivarMBWay(string accountNumber, string telefone, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            telefone = (telefone ?? string.Empty).Trim();

            // Validação simples de telemóvel português: 9 dígitos e a começar por 9.
            if (telefone.Length != 9 || !telefone.All(char.IsDigit) || !telefone.StartsWith("9"))
            {
                mensagemErro = "Número de telemóvel inválido (deve ter 9 dígitos e começar por 9).";
                return false;
            }

            if (_mbwayRepository.ContaTemMBWay(accountNumber))
            {
                mensagemErro = "Esta conta já tem o MBWay ativo.";
                return false;
            }

            if (_mbwayRepository.TelefoneJaUsado(telefone))
            {
                mensagemErro = "Este número de telemóvel já está associado a outra conta.";
                return false;
            }

            _mbwayRepository.Associar(telefone, accountNumber);
            return true;
        }

        // Envia dinheiro via MBWay da conta de origem para o telemóvel de destino.
        // Por trás, é uma transferência entre as duas contas, mas identificada como MBWay.
        public bool EnviarDinheiro(string accountNumberOrigem, string telefoneDestino, decimal valor, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            telefoneDestino = (telefoneDestino ?? string.Empty).Trim();

            // A conta de origem tem de ter o MBWay ativo.
            if (!_mbwayRepository.ContaTemMBWay(accountNumberOrigem))
            {
                mensagemErro = "Tem de ativar o MBWay antes de enviar dinheiro.";
                return false;
            }

            if (valor <= 0)
            {
                mensagemErro = "O valor tem de ser positivo.";
                return false;
            }

            // Descobre a conta de destino a partir do telemóvel.
            string? accountNumberDestino = _mbwayRepository.GetContaPorTelefone(telefoneDestino);
            if (accountNumberDestino == null)
            {
                mensagemErro = "O número de telemóvel de destino não tem MBWay associado.";
                return false;
            }

            var origem = _accountRepository.GetAccount(accountNumberOrigem);
            var destino = _accountRepository.GetAccount(accountNumberDestino);

            if (origem == null || destino == null)
            {
                mensagemErro = "Conta não encontrada.";
                return false;
            }

            if (origem.AccountNumber == destino.AccountNumber)
            {
                mensagemErro = "Não pode enviar dinheiro para o seu próprio MBWay.";
                return false;
            }

            if (origem.Balance < valor)
            {
                mensagemErro = "Saldo insuficiente!";
                return false;
            }

            // Move o dinheiro e guarda as duas contas.
            origem.Balance -= valor;
            destino.Balance += valor;
            _accountRepository.UpdateAccount(origem);
            _accountRepository.UpdateAccount(destino);

            // Regista o movimento nas duas contas, identificado como MBWay.
            _accountRepository.RegistarMovimento(new Movimento
            {
                IdConta   = origem.IdConta,
                Data      = DateTime.Now,
                Tipo      = "MBWay Enviado",
                Valor     = -valor,
                Descricao = $"MBWay para {telefoneDestino}"
            });
            _accountRepository.RegistarMovimento(new Movimento
            {
                IdConta   = destino.IdConta,
                Data      = DateTime.Now,
                Tipo      = "MBWay Recebido",
                Valor     = valor,
                Descricao = $"MBWay de {origem.AccountNumber}"
            });

            return true;
        }
    }
}
