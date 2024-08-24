using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces
{
    internal interface IProductoView
    {
        int IdProducto { get; set; }
        string CodigoProducto { get; set; }
        string Nombre { get; set; }
        int? IdCategoria { get; set; }
        decimal? PrecioVenta { get; set; }
        int? IdImpuesto { get; set; }
        int? IdProveedor { get; set; }
        decimal? PrecioCompra { get; set; }
        decimal? Descuento { get; set; }
        int? Existencia { get; set; }
        string NoLote { get; set; }
        int? StockMinimo { get; set; }
        int? StockMaximo { get; set; }
        DateTime? FechaElaboracion { get; set; }
        DateTime? FechaExpiracion { get; set; }
        string CodigoDeBarra { get; set; }
        string RutaFoto { get; set; }


        bool EsProductoFinal { get; set; }

        bool isEdit { get; set; }

        string Message { get; set; }

        event EventHandler LimpiarEvent;
        event EventHandler GuardarEvent;
        event EventHandler EditarEvent;
        event EventHandler DeleteEvent;
        event EventHandler SeleccionarFotoEvent;

        void SetProductoListBindingSource(BindingSource productoList);
        void SetCategoriaComboBox(IEnumerable<CategoriaModel> categorias);
        void SetImpuestoComboBox(IEnumerable<ImpuestoModel> impuestos);
        void SetProveedorComboBox(IEnumerable<ProveedorModel> proveedores);
        void LoadImage(string filepath);

    }
}
