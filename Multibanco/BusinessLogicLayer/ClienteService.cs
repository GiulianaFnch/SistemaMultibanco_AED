using Multibanco.Models;
using Multibanco.DataAccessLayer;
using System.Collections.Generic;

namespace Multibanco.BusinessLogicLayer
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository;

        public ClienteService()
        {
            _repository = new ClienteRepository();
        }

        public List<Cliente> ObterTodosClientes()
        {
            return _repository.ObterTodosClientes();
        }
    }
}