using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IMedidaRepository
    {
        void Add(MedidaModel model);
        void Update(MedidaModel model);
        void Delete(int id);
        IEnumerable<MedidaModel> GetAll();
    }
}
