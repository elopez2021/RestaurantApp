using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces
{
    internal interface IDepartamentoView
    {
        int IdDepartamento { get; set; }
        string Nombre { get; set; }
        int? IdSucursal { get; set; }
        
        string Message { get; set; }
        bool isEdit { get; set; }


        event EventHandler GuardarEvent;
        event EventHandler EditarEvent;
        event EventHandler DeleteEvent;
        event EventHandler LimpiarEvent;

        void SetDepartamentoListBindingSource(BindingSource departamentoList);
        void SetSucursalComboBox(IEnumerable<SucursalModel> sucursalList);
    }
}
