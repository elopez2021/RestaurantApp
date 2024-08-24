using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces
{
    internal interface IProveedorView
    {
        int IdProveedor { get; set; }

        string NombreProveedor { get; set; }

        string Telefono { get; set; }

        string NoDocumento { get; set; }

        int? IdTipoDocumento { get; set; }

        int? IdProvincia { get; set; }

        int? IdDepartamento { get; set; }

        string Direccion { get; set; }

        string Correo { get; set; }

        string NombreVendedor { get; set; }

        string Message { get; set; }
        bool isEdit { get; set; }


        event EventHandler GuardarEvent;
        event EventHandler EditarEvent;
        event EventHandler DeleteEvent;
        event EventHandler LimpiarEvent;

        void SetProveedorListBindingSource(BindingSource proveedorList);
        void SetTipoDocumentoComboBox(IEnumerable<TipoDocumentoModel> tipodocumentoList);
        void SetProvinciaComboBox(IEnumerable<ProvinciaModel> provinciaList);
        void SetDepartamentoComboBox(IEnumerable<DepartamentoModel> departamentoList);
    }
}
