using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface ICategoriaRepository
    {
        void Add(CategoriaModel model);
        void Update(CategoriaModel model);
        void Delete(int id);
        IEnumerable<CategoriaModel> GetAll();
    }
}
