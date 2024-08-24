using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    internal class ProveedorModel
    {
        [Browsable(false)]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El nombre de proveedor es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder de 50 caracteres")]
        public string NombreProveedor { get; set; }

        [Required(ErrorMessage = "El número de teléfono es requerido")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "El número de teléfono debe tener entre 10 y 11 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe ser un número.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El número de documento es requerido")]
        [MaxLength(20, ErrorMessage = "El nombre no puede exceder de 20 caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe ser un número.")]
        public string NoDocumento { get; set; }

        [Required(ErrorMessage = "El tipo de documento es requerido")]
        [Browsable(false)]
        public int? IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "La provincia es requerido")]
        [Browsable(false)]
        public int? IdProvincia { get; set; }
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El departamento es requerido")]
        [Browsable(false)]
        public int? IdDepartamento { get; set; }
        public string Departamento { get; set; }

        [Required(ErrorMessage = "La dirección es requerido")]
        [MaxLength(255, ErrorMessage = "El nombre no puede exceder de 255 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [MaxLength(100, ErrorMessage = "El correo electrónico no puede exceder 100 caracteres.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El nombre de vendedor es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder de 100 caracteres")]
        public string NombreVendedor { get; set; }
        
        [Browsable(false)]
        public bool Estado { get; set;}

    }
}