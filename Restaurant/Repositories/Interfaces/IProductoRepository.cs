using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    interface IProductoRepository
    {
        void Add(ProductoModel model);
        void Update(ProductoModel model);
        void Delete(int id);
        IEnumerable<ProductoModel> GetAll();
        IEnumerable<ProductoModel> GetAllNotExpired();
    }
}
