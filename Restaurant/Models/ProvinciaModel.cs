using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class ProvinciaModel
    {
        [Key]
        public int IdProvincia { get; set; }

        [Required(ErrorMessage = "El nombre de la provincia es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre de la provincia debe tener entre 1 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código de la provincia es requerido")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El código de la provincia debe tener entre 1 y 10 caracteres.")]
        public string Codigo { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
