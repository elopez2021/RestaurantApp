using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class ImpuestoModel
    {
        [Browsable(false)]
        public int IdImpuesto { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad de personas es requerida")]
        [RegularExpression(@"^\d{1,5}(\.\d{2})?$", ErrorMessage = "Formato de porcentaje inválido. Solo se permiten hasta 5 dígitos antes del punto y exactamente 2 dígitos después del punto.")]
        public decimal? Porcentaje { get; set; }

        [Browsable(false)]
        public bool Estado { get; set; }
    }
}
