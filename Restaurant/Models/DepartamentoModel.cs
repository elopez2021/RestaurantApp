using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class DepartamentoModel
    {
        [Browsable(false)]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "La sucursal es requerida")]
        [Browsable(false)]
        public int? IdSucursal { get; set; }

        public string Sucursal { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder de 50 caracteres")]
        public string Nombre { get; set; }
        
        [Browsable(false)]
        public bool Estado { get; set; }
    }
}
