using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IMesaRepository
    {
        void Add(MesaModel salaModel);
        void Update(MesaModel salaModel);
        void Delete(int id);
        IEnumerable<MesaModel> GetAll();
        IEnumerable<MesaModel> GetMesaBySala(int idsala);
    }
}
