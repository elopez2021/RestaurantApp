
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces
{
    internal interface ISalaView
    {
        int IdSala { get; set; }
        string Nombre { get; set; }
        int? IdSucursal { get; set; }

        string Message { get; set; }
        bool isEdit { get; set; }


        event EventHandler GuardarEvent;
        event EventHandler EditarEvent;
        event EventHandler DeleteEvent;
        event EventHandler LimpiarEvent;

        void SetSalaListBindingSource(BindingSource salaList);
        void SetSucursalesComboBox(IEnumerable<SucursalModel> sucursalList);
    }
}
