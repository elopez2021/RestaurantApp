using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IPedidoRepository
    {
        int Add(PedidoModel model, List<PedidoProductoModel> orderItems); //returns the idpedido
               
        void SetPedidoEntregado(int idPedido, int idMesa);

        IEnumerable<PedidoModel> GetAllPendientes();
        IEnumerable<PedidoProductoModel> GetPedidoProductos(int idPedido);

    }
}
