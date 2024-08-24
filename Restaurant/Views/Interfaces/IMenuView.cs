using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views
{
    internal interface IMenuView
    {
        //Properties

        string nombre { get; set; }
        int IdTipoUsuario { get; set; }

        //Events
        event EventHandler ShowUsuarioView;
        event EventHandler ShowClienteView;
        event EventHandler ShowCategoriaView;
        event EventHandler ShowSalaView;
        event EventHandler ShowMesaView;
        event EventHandler ShowDepartamentoView;
        event EventHandler ShowMonedaView;
        event EventHandler ShowImpuestoView;
        event EventHandler ShowMedidaView;
        event EventHandler ShowProveedorView;
        event EventHandler ShowProductoView;
        event EventHandler ShowPOSView;
        event EventHandler ShowReporteView;
        void AddControls(Form f);
    }
}
