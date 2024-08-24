using Restaurant.Presenters;
using Restaurant.Views;
using Restaurant.Views.Interfaces;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Presenters.Movimientos;
using System.Web.UI.WebControls;
using Restaurant.Views.Interfaces.Movimientos;
using Restaurant.Views.Movimientos;

namespace Restaurant.Repositories
{
    internal class MainPresenter
    {
        private Menu mainView;
        private int? idtipousuario;
        private readonly string sqlConnectionString;
        private readonly int idsucursal;
        private readonly int idusuario;
        
        public MainPresenter(Menu mainView, string sqlConnectionString, int? tipousuario, string nombre, int idsucursal, int idusuario)
        {
            this.mainView = mainView;
            idtipousuario = tipousuario;
            this.mainView.IdTipoUsuario = (int)idtipousuario;
            this.mainView.nombre = nombre;
            this.mainView.Show();

            this.idusuario = idusuario;

            if (tipousuario == 1) 
            {
                this.mainView.ShowUsuarioView += ShowUsuariosView;
                this.mainView.ShowClienteView += ShowClienteView;
                this.mainView.ShowCategoriaView += ShowCategoriaView;
                this.mainView.ShowSalaView += ShowSalaView;
                this.mainView.ShowMesaView += ShowMesaView;
                this.mainView.ShowDepartamentoView += ShowDepartamentoView;
                this.mainView.ShowMonedaView += ShowMonedaView;
                this.mainView.ShowImpuestoView += ShowImpuestoView;
                this.mainView.ShowMedidaView += ShowMedidaView;
                this.mainView.ShowProveedorView += ShowProveedorView;
                this.mainView.ShowProductoView += ShowProductoView;
                this.mainView.ShowReporteView += ShowReporteView;
            }

            this.mainView.ShowPOSView += ShowPOSView;
            this.idsucursal = idsucursal;
            this.sqlConnectionString = sqlConnectionString;
        }

        private void ShowReporteView(object sender, EventArgs e)
        {
            IVentasReportRepository salesrepo = new VentasRepository(sqlConnectionString);

            IReporteVentasView view = new ReporteVentas();

            this.mainView.AddControls((Form)view);

            new ReportePresenter(view, salesrepo, this.mainView.nombre);
        }

        private void ShowPOSView(object sender, EventArgs e)
        {
            IPOSView view = new POS();
            ICategoriaRepository categoriarepo = new CategoriaRepository(sqlConnectionString);
            IMesaRepository mesarepo = new MesaRepository(sqlConnectionString);
            ISalaRepository salarepo = new SalaRepository(sqlConnectionString);
            IProductoRepository productorepo = new ProductoRepository(sqlConnectionString);

            IPedidoRepository pedidorepo = new PedidoRepository(sqlConnectionString);

            this.mainView.AddControls((Form)view);

            new POSPresenter(view, productorepo, pedidorepo, categoriarepo, mesarepo, salarepo, sqlConnectionString, idsucursal, idusuario);
        }

        private void ShowProductoView(object sender, EventArgs e)
        {
            ICategoriaRepository categoriarepo = new CategoriaRepository(sqlConnectionString);
            IProveedorRepository proveedorrepo = new ProveedorRepository(sqlConnectionString);
            IImpuestoRepository impuestorepo = new ImpuestoRepository(sqlConnectionString);
            IProductoRepository productorepo = new ProductoRepository(sqlConnectionString);

            IProductoView view = new MantProductos();
            this.mainView.AddControls((Form)view);

            new ProductoPresenter(view, productorepo, categoriarepo, proveedorrepo, impuestorepo);
        }

        private void ShowProveedorView(object sender, EventArgs e)
        {
            IProvinciaRepository provinciarepo = new ProvinciaRepository(sqlConnectionString);
            ITipoDocumentoRepository tipodocrepo = new TipoDocumentoRepository(sqlConnectionString);
            IProveedorRepository proveedorrepo = new ProveedorRepository(sqlConnectionString);
            IDepartamentoRepository departamentorepo = new DepartamentoRepository(sqlConnectionString);
            IProveedorView view = new MantProveedor();

            this.mainView.AddControls((Form)view);

            new ProveedorPresenter(proveedorrepo, provinciarepo, tipodocrepo, departamentorepo, view);
        }

        private void ShowMedidaView(object sender, EventArgs e)
        {
            IMedidaRepository repo = new MedidaRepository(sqlConnectionString);
            IMedidaView view = new MantMedidas();

            this.mainView.AddControls((Form)view);

            new MedidaPresenter(view, repo);
        }

        private void ShowImpuestoView(object sender, EventArgs e)
        {
            IImpuestoView view = new MantImpuestos();
            IImpuestoRepository repo = new ImpuestoRepository(sqlConnectionString);

            this.mainView.AddControls((Form)view);

            new ImpuestoPresenter(view, repo);
        }

        private void ShowMonedaView(object sender, EventArgs e)
        {
            IMonedaView view = new MantMoneda();
            IMonedaRepository repo = new MonedaRepository(sqlConnectionString);

            this.mainView.AddControls((Form)view);
            new MonedaPresenter(view, repo);
        }

        private void ShowDepartamentoView(object sender, EventArgs e)
        {
            IDepartamentoView view = new MantDepartamentos();
            IDepartamentoRepository departamentorepo = new DepartamentoRepository(sqlConnectionString);
            ISucursalRepository sucursalrepo = new SucursalRepository(sqlConnectionString);

            this.mainView.AddControls((Form)view);
            new DepartamentoPresenter(view, departamentorepo, sucursalrepo);

        }

        private void ShowMesaView(object sender, EventArgs e)
        {
            IMesaView view = new MantMesas();
            ISalaRepository salarepo = new SalaRepository(sqlConnectionString);
            IMesaRepository mesarepo = new MesaRepository(sqlConnectionString);

            this.mainView.AddControls((Form)view);

            new MesaPresenter(view, mesarepo, salarepo);
        }

        private void ShowSalaView(object sender, EventArgs e)
        {
            ISalaView view = new MantSalas();
            ISalaRepository salarepo = new SalaRepository(sqlConnectionString);
            ISucursalRepository sucursalrepo = new SucursalRepository(sqlConnectionString);

            this.mainView.AddControls((Form)view);

            new SalaPresenter(view, salarepo, sucursalrepo);

        }

        private void ShowCategoriaView(object sender, EventArgs e)
        {
            ICategoriaRepository repository = new CategoriaRepository(sqlConnectionString);
            ICategoriaView view = new MantCategorias();

            this.mainView.AddControls((Form)view);
            new CategoriaPresenter(view, repository);

        }

        private void ShowClienteView(object sender, EventArgs e)
        {
            IClienteRepository clienterepo = new ClienteRepository(sqlConnectionString);
            ITipoClienteRepository tipoclienterepo = new TipoClienteRepository(sqlConnectionString);
            IProvinciaRepository provinciarepo = new ProvinciaRepository(sqlConnectionString);
            ITipoDocumentoRepository tipodocrepo = new TipoDocumentoRepository(sqlConnectionString);
            IClienteView clienteview = new MantClientes();

            this.mainView.AddControls((Form)clienteview);
            new ClientePresenter(clienteview, clienterepo, tipodocrepo, tipoclienterepo, provinciarepo);
            
        }

        private void ShowUsuariosView(object sender, EventArgs e)
        {
            IUsuarioRepository usuariorepo = new UsuarioRepository(sqlConnectionString);
            ISucursalRepository sucursalrepo = new SucursalRepository(sqlConnectionString);
            IUsuarioView usuarioview = new MantUser();
            this.mainView.AddControls((Form)usuarioview);
            new UsuarioPresenter(usuarioview, usuariorepo, sucursalrepo, new TipoUsuarioRepository(sqlConnectionString) );
        }
        
    }
}
