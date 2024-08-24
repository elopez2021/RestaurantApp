using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }

        [Browsable(false)]
        public int IdPedido { get; set; }
        
        [Required(ErrorMessage = "El total es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El total debe tener como máximo dos decimales")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El impuesto es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El impuesto debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El impuesto debe tener como máximo dos decimales")]
        public decimal Impuesto { get; set; }

        public string NombreCliente { get; set; } //this is only for receipt
        public string NombreUsuario { get; set; } //this is only for receipt

        [Required(ErrorMessage = "El subtotal es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El subtotal debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El subtotal debe tener como máximo dos decimales")]
        public decimal SubTotal { get; set; }

        [Browsable(false)]
        public bool Estado { get; set; } = false;

        public DateTime Fecha { get; set; }
    }
}
