using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface ISalaRepository
    {
        void Add(SalaModel salaModel);
        void Update(SalaModel salaModel);
        void Delete(int id);
        IEnumerable<SalaModel> GetAll();

        IEnumerable<SalaModel> GetAllBySucursal(int idsucursal);
    }
}
