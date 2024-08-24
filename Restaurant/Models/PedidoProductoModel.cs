using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class PedidoProductoModel
    {
        [Browsable(false)]
        public int IdPedido { get; set; }

        [Browsable(false)]
        [Required(ErrorMessage = "El producto es requerido")]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un valor positivo mayor que cero")]
        public int Cantidad { get; set; }

        public decimal Impuesto { get; set; } //this field is for the receipt
        public string CodigoProducto { get; set; }//this field is for the receipt

        [Required(ErrorMessage = "El precio unitario es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio unitario debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El precio unitario del producto debe tener como máximo dos decimales")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "El precio total es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio total debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El precio total del producto debe tener como máximo dos decimales")]
        public decimal PrecioTotal { get; set; }
    }
}
