using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IProveedorRepository
    {
        void Add(ProveedorModel model);
        void Update(ProveedorModel model);
        void Delete(int id);
        IEnumerable<ProveedorModel> GetAll();
    }
}
