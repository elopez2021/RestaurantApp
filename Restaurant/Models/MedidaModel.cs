using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class MedidaModel
    {
        [Browsable(false)]
        public int IdMedida { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La sigla es requerido")]
        [MaxLength(5, ErrorMessage = "La sigla no puede exceder de 5 caracteres")]
        public string Sigla { get; set; }

        [Browsable(false)]
        public bool Estado { get; set; }
    }
}
