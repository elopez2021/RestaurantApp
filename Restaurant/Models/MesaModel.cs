using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class MesaModel
    {
        [Browsable(false)]
        public int IdMesa { get; set; }
        
        [Required(ErrorMessage = "La sala es requerida")]
        [Browsable(false)]
        public int? IdSala { get; set; }

        public string Sala { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad de personas es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de personas es requerida debe ser mayor o igual a 1.")]
        public int CantidadPersona { get; set; }

        
        public bool Disponible { get; set; }

        [Browsable(false)]
        public bool Estado { get; set; }
    }
}
