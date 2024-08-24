using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class SalaModel
    {
        [Browsable(false)]
        public int IdSala { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La sucursal es requerida")]
        [Browsable(false)]
        public int? IdSucursal { get; set; }
        public string Sucursal { get; set; }

        [Browsable(false)]
        public bool Estado { get; set; }
    }
}
