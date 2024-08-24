using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class CategoriaModel
    {
        [Browsable(false)]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder de 100 caracteres")]
        public string Nombre { get; set; }
        [Browsable(false)]
        public bool Estado { get; set; }
    }
}
