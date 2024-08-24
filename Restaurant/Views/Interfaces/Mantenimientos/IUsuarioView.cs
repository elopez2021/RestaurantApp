using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Models;

namespace Restaurant.Views.Interfaces
{
    internal interface IUsuarioView
    {
        int IdUsuario { get; set; }
        string NoDocumento { get; set; } 
        string Usuario { get; set; } 
        string Contrasena { get; set; } 
        int? IdTipoUsuario { get; set; } 
        string Nombre { get; set; }
        string Correo { get; set; }
        int? IdSexo { get; set; } 
        string Direccion { get; set; } 
        int? IdSucursal { get; set; }
        string Telefono { get; set; }
        decimal? Comision { get; set; }
        bool? Estatus { get; set; }
        string Message { get; set; }
        bool isEdit { get; set; }

        event EventHandler LimpiarEvent;
        event EventHandler GuardarEvent;
        event EventHandler EditEvent;

        void SetUsuarioListBindingSource(BindingSource usuarioList);
        void SetSucursalesComboBox(IEnumerable<SucursalModel> sucursalList);
        void SetTipoUsuariosComboBox(IEnumerable<TipoUsuarioModel> tipoList);


        
    }
}
