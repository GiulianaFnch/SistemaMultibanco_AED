using Multibanco.Models;
using Multibanco.DataAccessLayer;

namespace Multibanco.BusinessLogicLayer
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository = new ClienteRepository();
        public List<Cliente> ObterTodosClientes() => _repository.ObterTodosClientes();
        public void AdicionarCliente(string nome, string nif) => _repository.AdicionarCliente(nome, nif);
        public bool EliminarCliente(int id) => _repository.EliminarCliente(id);
        public List<BankAccount> ObterTodasContas() => _repository.ObterTodasContas();
        public void AdicionarConta(int idCliente, string num, string pin) => _repository.AdicionarConta(idCliente, num, pin);
    }
}