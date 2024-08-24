using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    internal class SucursalModel
    {
        private int _idSucursal;
        private string _nombre;
        private string _direccion;
        private string _telefono;
        private string _ciudad;
        private string _estado;
        private string _codigoPostal;
        private DateTime _fechaApertura;
        private string _gerente;
        private DateTime _fechaCreacion;

        
    
        public int IdSucursal
        {
            get { return _idSucursal; }
            set { _idSucursal = value; }
        }

        [Required]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        [Required]
        [MaxLength(100, ErrorMessage = "La dirección no puede exceder 100 caracteres.")]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        [Required]
        [MaxLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres.")]
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        [Required]
        [MaxLength(50, ErrorMessage = "La ciudad no puede exceder 50 caracteres.")]
        public string Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        [Required]
        [MaxLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres.")]
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


        [Required]
        [MaxLength(10, ErrorMessage = "El código postal no puede exceder 10 caracteres.")]
        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set { _codigoPostal = value; }
        }

        [Required]
        [Display(Name = "Fecha de Apertura")]
        public DateTime FechaApertura
        {
            get { return _fechaApertura; }
            set { _fechaApertura = value; }
        }

        [Required]
        [MaxLength(50, ErrorMessage = "El nombre del gerente no puede exceder 50 caracteres.")]
        public string Gerente
        {
            get { return _gerente; }
            set { _gerente = value; }
        }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
    }
}
