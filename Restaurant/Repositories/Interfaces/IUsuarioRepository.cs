using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Restaurant.Repositories
{
    internal interface IUsuarioRepository
    {
        void Add(UsuarioModel usuarioModel);
        void Update(UsuarioModel usuarioModel);
        IEnumerable<UsuarioModel> GetAll();
        IEnumerable<UsuarioModel> GetByValue(string value);
    }
}
