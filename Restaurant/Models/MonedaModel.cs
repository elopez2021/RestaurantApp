using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class MonedaModel
    {
        [Browsable(false)]
        public int IdMoneda { get;set; }
        [Required(ErrorMessage = "El nombre de la moneda es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La sigla de la moneda es requerida")]
        [MaxLength(10, ErrorMessage = "La sigla no puede exceder de 10 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "El simbolo de la moneda es requerido")]
        [MaxLength(5, ErrorMessage = "La simbolo no puede exceder de 5 caracteres")]
        public string Simbolo { get; set; }

        [Browsable(false)]
        public bool Estado { get; set; }
    }
}
