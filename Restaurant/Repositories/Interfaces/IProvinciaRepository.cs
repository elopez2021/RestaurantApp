using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IProvinciaRepository
    {
        void Add(ProvinciaModel provinciaModel);
        void Update(ProvinciaModel provinciaModel);
        IEnumerable<ProvinciaModel> GetAll();
        IEnumerable<ProvinciaModel> GetByValue(string value);
    }
}
