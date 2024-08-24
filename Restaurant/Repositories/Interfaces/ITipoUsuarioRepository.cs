using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface ITipoUsuarioRepository
    {
        void Add(TipoUsuarioModel tipousuarioModel);
        void Update(TipoUsuarioModel tipousuarioModel);
        IEnumerable<TipoUsuarioModel> GetAll();
        IEnumerable<TipoUsuarioModel> GetByValue(string value);
    }
}
