using Restaurant.Models;
using Restaurant.Views.Interfaces.Movimientos.UserControls;
using Restaurant.Views.Movimientos.POS_Paneles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces.Movimientos
{
    internal interface IPOSView
    {
        string ProductoSearch { get;set; }
        int? IdCliente {  get; set; }
        string NombreCliente { get; set; }
        int? IdMesa { get; set; }
        decimal Total { get;set; }
        decimal SubTotal { get; set; }
        decimal Impuesto { get; set; }

        string Message { get; set; }
        bool isEdit { get; set; }

        DataGridViewRow[] GetCartTableRows();

        void AddToCart(controlproductos wdg);



        void SetSalaComboBox(IEnumerable<SalaModel> salaList);
        void SetCategoriaComboBox(IEnumerable<CategoriaModel> categoriaList);



        void SetProductoList(IEnumerable<ProductoModel> productoList);
        void SetMesaList(IEnumerable<MesaModel> mesaList);


        void ClearCartItems();

        event EventHandler onSelectProducto;
        event EventHandler ShowFacturas;
        event EventHandler ShowPedidosPendientes;
        event EventHandler BuscarCliente;
        event EventHandler SolicitarPedido;
        event EventHandler BorrarItems;
    }
}
