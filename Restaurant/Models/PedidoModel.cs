using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace Restaurant.Models
{
    public class PedidoModel
    {
        [Browsable(false)]
        public int IdPedido { get; set; }

        [Browsable(false)]
        [Required(ErrorMessage = "El usuario es requerido")]
        public int? IdUsuario { get; set; }       
        public string NombreUsuario { get; set; }

        [Browsable(false)]
        [CustomValidation(typeof(PedidoModel), nameof(ValidateCliente))]
        public int? IdCliente { get; set; }
               

        [MaxLength(100, ErrorMessage = "El nombre del cliente no puede exceder de 100 caracteres")]
        public string Cliente { get; set; }

        [Browsable(false)]
        [Required(ErrorMessage = "La mesa es requerida")]
        public int? IdMesa { get; set; }

        public string NombreMesa { get; set; }

        [Required(ErrorMessage = "El total es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El total debe tener como máximo dos decimales")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El impuesto es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El impuesto debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El impuesto debe tener como máximo dos decimales")]
        public decimal Impuesto { get; set; }

        [Required(ErrorMessage = "El subtotal es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El subtotal debe ser un valor positivo")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "El subtotal debe tener como máximo dos decimales")]
        public decimal SubTotal { get; set; }


        public DateTime Fecha { get; set; }      
        
        public bool Estado { get; set; } = false;


        public static ValidationResult ValidateCliente(int? idCliente, ValidationContext context)
        {

            var instance = context.ObjectInstance as PedidoModel;
            if (string.IsNullOrEmpty(instance.Cliente) && idCliente == null)
            {
                return new ValidationResult("El cliente es requerido.");
            }
            return ValidationResult.Success;
        }
    }
}
