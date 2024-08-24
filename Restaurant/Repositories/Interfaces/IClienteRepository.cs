using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IClienteRepository
    {
        void Add(ClienteModel clienteModel);
        void Update(ClienteModel clienteModel);
        void Delete(int id);
        IEnumerable<ClienteModel> GetAll();
    }
}
