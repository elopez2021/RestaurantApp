using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class TipoClienteModel
    {
        public int IdTipoCliente { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
