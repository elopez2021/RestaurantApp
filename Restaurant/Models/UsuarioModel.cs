using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Restaurant.Models
{
    internal class UsuarioModel
    {
        private int _idUsuario;
        private string _noDocumento;
        private string _usuario;
        private string _contrasena;
        private int? _idTipo;
        private string _nombre;
        private string _telefono;
        private string _correo;
        private int? _idSexo;
        private string _direccion;
        private int? _idSucursal;
        private bool? _estatus;
        private decimal? _comision = 0.0m;
        private DateTime _fechaCreacion;


        public override string ToString()
        {
            return $"ID Usuario: {IdUsuario}, " +
                   $"Número de Documento: {NoDocumento}, " +
                   $"Nombre: {Nombre}, " +
                   $"IdSexo: {IdSexo}, " +
                   $"Dirección: {Direccion}, " +
                   $"Teléfono: {Telefono}, " +
                   $"Correo Electrónico: {Correo}, " +
                   $"IdTipo de Usuario: {IdTipo}, " +
                   $"Estatus: {Estatus}, " +
                   $"Comisión por ventas: {Comision:C2}, " +
                   $"IdSucursal: {IdSucursal}, " +
                   $"Fecha de Creación: {FechaCreacion:d}";
        }


        //mostrar las descripciones de los IDs





        [Browsable(false)]
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        [Required(ErrorMessage = "El número de documento es requerido")]
        [MaxLength(20, ErrorMessage = "El número de documento no puede exceder 20 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe ser un número.")]
        [Display(Order = 1)]
        public string NoDocumento
        {
            get { return _noDocumento; }
            set { _noDocumento = value; }
        }

        [Required]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Sexo { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "La dirección no puede exceder 150 caracteres.")]
        [Display(Name = "Dirección", Order = 3)]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        [Required]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "El número de teléfono debe tener entre 10 y 11 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo {0} debe ser un número.")]
        [Display(Order = 4)]
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        

        [Required]
        [MaxLength(100, ErrorMessage = "El nombre de usuario no puede exceder 100 caracteres.")]
        [Display(Order = 2)]
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        [Required]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [MaxLength(100, ErrorMessage = "El correo electrónico no puede exceder 100 caracteres.")]
        [Display(Name = "Correo Electrónico", Order = 5)]
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        [Display(Order = 6, Name = "Acceso")]
        public string TipoUsuario { get; set; }

        [Required]
        [Display(Name = "Estatus", Order = 7)]
        public bool? Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        [Range(0, 100, ErrorMessage = "La comisión debe ser un valor entre 0 y 100 (porcentaje).")]
        [Display(Name = "Comisión por ventas", Order = 8)]
        public decimal? Comision
        {
            get { return _comision; }
            set { _comision = value; }
        }

        [Display(Order = 9, Name = "Sucursal")]
        public string Sucursal { get; set; }


        //Browsable = false

        [Required]
        [MaxLength(100, ErrorMessage = "La contraseña no puede exceder 100 caracteres.")]
        [Browsable(false)]
        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }     

        

        [Required]
        [Display(Name = "ID Sexo")]
        [Browsable(false)]
        public int? IdSexo
        {
            get { return _idSexo; }
            set { _idSexo = value; }
        }

        [Required]
        [Display(Name = "ID Tipo")]
        [Browsable(false)]
        public int? IdTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }

        

        [Required]
        [Display(Name = "ID Sucursal")]
        [Browsable(false)]
        public int? IdSucursal
        {
            get { return _idSucursal; }
            set { _idSucursal = value; }
        }

        

        [Required]
        [Display(Name = "Fecha de Creación")]
        [Browsable(false)]
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        
        /*
        [Display(Name = "Nombre Completo")]
        public string DisplayName
        {
            get { return $"{Nombre} {Apellido}"; }
        }*/
    }
}
