using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface ITipoDocumentoRepository
    {
        void Add(TipoDocumentoModel tipoModel);
        void Update(TipoDocumentoModel tipoModel);
        IEnumerable<TipoDocumentoModel> GetAll();
        IEnumerable<TipoDocumentoModel> GetByValue(string value);
    }
}
