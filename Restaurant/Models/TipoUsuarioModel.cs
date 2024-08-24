using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class TipoUsuarioModel
    {
        public int IdTipo { get; set; }
 
        [Required(ErrorMessage = "La descripción del tipo de usuario es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La descripción debe tener entre 1 y 100 caracteres.")]
        public string Descripcion { get; set; }
    }
}
