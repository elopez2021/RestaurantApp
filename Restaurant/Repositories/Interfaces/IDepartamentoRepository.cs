using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IDepartamentoRepository
    {
        void Add(DepartamentoModel model);
        void Update(DepartamentoModel model);
        void Delete(int id);
        IEnumerable<DepartamentoModel> GetAll();
    }
}
