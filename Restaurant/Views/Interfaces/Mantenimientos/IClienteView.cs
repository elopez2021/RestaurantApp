using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces
{
    internal interface IClienteView
    {
        int IdCliente { get; set; }
        int? IdTipoCliente { get; set; }
        int? IdTipoDocumento { get; set; }
        string NoDocumento { get; set; }
        string Nombre { get; set; }
        string RazonSocial { get; set; }
        string GiroCliente { get; set; }
        string Telefono { get; set; }
        string Correo { get; set; }
        int? IdProvincia { get; set; }
        string Direccion { get; set; }
        decimal? LimiteCredito { get; set; }
        bool isEdit { get; set;}

        string Message { get; set; }

        event EventHandler LimpiarEvent;
        event EventHandler GuardarEvent;
        event EventHandler EditarEvent;
        event EventHandler DeleteEvent;

        void SetClienteListBindingSource(BindingSource clienteList);
        void SetTipoClienteComboBox(IEnumerable<TipoClienteModel> tipoclienteList);
        void SetTipoDocumentoComboBox(IEnumerable<TipoDocumentoModel> tipodocumentoList);

        void SetProvinciaComboBox(IEnumerable<ProvinciaModel> provinciaList);
    }
}
