using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    internal class ClienteModel
    {
        private int _idCliente;
        private int? _tipoClienteId;
        private int? _tipoDocumentoId;
        private string _noDocumento;
        private string _nombre;
        private string _razonSocial;
        private string _giroCliente;
        private string _telefono;
        private string _correo;
        private int? _provinciaId;
        private string _direccion;
        private decimal? _limiteCredito;
        private bool? _estatus;
        private DateTime _fechaCreacion;

        public override string ToString()
        {
            return $"ID Cliente: {IdCliente}, " +
                   $"Número de Documento: {NoDocumento}, " +
                   $"Nombre: {Nombre}, " +
                   $"ID Tipo: {IdTipoCliente}, " +
                   $"Razón Social: {RazonSocial}, " +
                   $"Giro del Cliente: {GiroCliente}, " +                   
                   $"Teléfono: {Telefono}, " +
                   $"Correo Electrónico: {Correo}, " +
                   $"ID Provincia: {IdProvincia}, " +
                   $"Dirección: {Direccion}, " +
                   $"Límite de Crédito: {LimiteCredito:C2}, " +
                   $"Estatus: {Estatus}, " +
                   $"Fecha de Creación: {FechaCreacion:d}";
        }

        [Browsable(false)]
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        [Required(ErrorMessage = "El tipo de cliente es requerido")]
        [Display(Name = "Tipo de Cliente")]
        [Browsable(false)]
        public int? IdTipoCliente
        {
            get { return _tipoClienteId; }
            set { _tipoClienteId = value; }
        }

        public string TipoCliente { get; set; }

        [Required(ErrorMessage = "El tipo de documento es requerido")]
        [Display(Name = "Tipo de Documento")]
        [Browsable(false)]
        public int? IdTipoDocumento
        {
            get { return _tipoDocumentoId; }
            set { _tipoDocumentoId = value; }
        }

        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es requerido")]
        [MaxLength(20, ErrorMessage = "El número de documento no puede exceder 20 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe ser un número.")]
        [Display(Name = "Número de Documento", Order = 1)]
        public string NoDocumento
        {
            get { return _noDocumento; }
            set { _noDocumento = value; }
        }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        [Display(Name = "Nombre", Order = 2)]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        [Required(ErrorMessage = "La razón social es requerida")]
        [MaxLength(100, ErrorMessage = "La razón social no puede exceder 100 caracteres.")]
        [Display(Name = "Razón Social")]
        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        [Required(ErrorMessage = "El giro del cliente es requerido")]
        [MaxLength(100, ErrorMessage = "El giro del cliente no puede exceder 100 caracteres.")]
        [Display(Name = "Giro del Cliente")]
        public string GiroCliente
        {
            get { return _giroCliente; }
            set { _giroCliente = value; }
        }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "El número de teléfono debe tener entre 10 y 20 caracteres.")]
        [Display(Name = "Teléfono", Order = 3)]
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [MaxLength(100, ErrorMessage = "El correo electrónico no puede exceder 100 caracteres.")]
        [Display(Name = "Correo Electrónico", Order = 4)]
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        [Required(ErrorMessage = "La provincia es requerida")]
        [Display(Name = "ID Provincia")]
        [Browsable(false)]
        public int? IdProvincia
        {
            get { return _provinciaId; }
            set { _provinciaId = value; }
        }

        public string Provincia { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [MaxLength(150, ErrorMessage = "La dirección no puede exceder 150 caracteres.")]
        [Display(Name = "Dirección", Order = 5)]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        
        [Range(0, double.MaxValue, ErrorMessage = "El límite de crédito debe ser un valor positivo.")]
        [Display(Name = "Límite de Crédito", Order = 6)]
        public decimal? LimiteCredito
        {
            get { return _limiteCredito; }
            set { _limiteCredito = value; }
        }

        [Display(Name = "Estatus")]
        public bool? Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
    }
}
