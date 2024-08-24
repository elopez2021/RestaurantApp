using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IMonedaRepository
    {
        void Add(MonedaModel model);
        void Update(MonedaModel model);
        void Delete(int id);
        IEnumerable<MonedaModel> GetAll();
    }
}
