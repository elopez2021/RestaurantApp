using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface ISucursalRepository
    {
        void Add(SucursalModel sucursalModel);
        void Update(SucursalModel sucursalModel);
        IEnumerable<SucursalModel> GetAll();
        IEnumerable<SucursalModel> GetByValue(string value);
        
    }
}
