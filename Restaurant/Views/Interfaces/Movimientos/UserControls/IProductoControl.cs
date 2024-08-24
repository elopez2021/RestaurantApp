using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Views.Interfaces.Movimientos.UserControls
{
    internal interface IProductoControl
    {
        int IdProducto { get; set; }
        string CodigoProducto { get; set; }
        decimal Precio { get; set; }
        int IdCategoria { get; set; }
        decimal Impuesto { get;set; }
        string Nombre { get; set; }
        string Imagen { get;set; }

        int? CantidadMaxima { get; set; }
        bool EsProductoFinal { get; set; }

        void LoadImage(string filepath);

        event EventHandler onSelectProducto;
    }
}
