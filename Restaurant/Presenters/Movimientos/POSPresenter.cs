using Restaurant.Models;
using Restaurant.Presenters.Common;
using Restaurant.Repositories;
using Restaurant.Repositories.Interfaces;
using Restaurant.Views.Interfaces;
using Restaurant.Views.Interfaces.Movimientos;
using Restaurant.Views.Interfaces.Movimientos.UserControls;
using Restaurant.Views.Movimientos;
using Restaurant.Views.Movimientos.controlesReportes;
using Restaurant.Views.Movimientos.POS_controles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Presenters.Movimientos
{
    internal class POSPresenter
    {
        private IPOSView view;
        private string connectionString;
        private IProductoRepository productorepo;
        private IPedidoRepository pedidorepo;
        private ICategoriaRepository categoriarepo;
        private IMesaRepository mesarepo;
        private ISalaRepository salarepo;
        private IFacturaRepository facturarepo;
        private readonly int idusuario;

        public POSPresenter(IPOSView view, IProductoRepository productorepo, IPedidoRepository pedidorepo, ICategoriaRepository categoriarepo, IMesaRepository mesarepo, ISalaRepository salarepo, string connectionString, int idsucursal, int idusuario)
        {
            this.productorepo = productorepo;
            this.pedidorepo = pedidorepo;
            this.categoriarepo = categoriarepo;
            this.mesarepo = mesarepo;
            this.salarepo = salarepo;
            this.view = view;
            this.connectionString = connectionString;
            this.idusuario = idusuario;

            facturarepo = new FacturaRepository(connectionString);

            this.view.ShowFacturas += ShowFacturas;
            this.view.BuscarCliente += BuscarCliente;
            this.view.SolicitarPedido += SolicitarPedido;
            this.view.ShowPedidosPendientes += ShowPedidosPendientes;
            

            LoadAllProducto();
            LoadAllCategoria();
            LoadAllSalaBySucursal(idsucursal);
            LoadAllMesas();
        }

        private void ShowFacturas(object sender, EventArgs e)
        {
            IFacturaView view = controlesfacturas.GetInstance();

            var facturalist = facturarepo.GetAll();
            DataTable datatable = DataTableConverter.ConvertToDataTable(facturalist.ToList());

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = datatable;
            view.SetFacturaBindingSource(bindingSource);

            view.PrintFactura += (ss, ee) =>
            {
                var currentRow = bindingSource.Current as DataRowView;
                if (currentRow != null)
                {
                    int idfactura = (int)currentRow["IdFactura"];
                    ShowFacturaReportWrapper(idfactura, view);
                }
            };


        }

        private void ShowPedidosPendientes(object sender, EventArgs e)
        {
            IPedidosPendientesView pedidosview = controlpendientes.GetInstance();
            IEnumerable<PedidoModel> list = pedidorepo.GetAllPendientes();

            DataTable datatable = DataTableConverter.ConvertToDataTable(list.ToList());

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = datatable;
            pedidosview.SetPedidosBindingSource(bindingSource);

            pedidosview.SetPedidoEntregado += (ss, ee) =>
            {
                var currentRow = bindingSource.Current as DataRowView;
                if (currentRow != null)
                {
                    int idPedido = Convert.ToInt32(currentRow["IdPedido"]);
                    int idMesa = Convert.ToInt32(currentRow["IdMesa"]);
                    decimal impuesto = (decimal)currentRow["Impuesto"];
                    decimal total = (decimal)currentRow["Total"];
                    decimal subtotal = (decimal)currentRow["SubTotal"];
                    try
                    {
                        pedidorepo.SetPedidoEntregado(idPedido, idMesa);
                        pedidosview.Message = "Se ha cambiado el estado satisfactoriamente";

                        bindingSource.RemoveCurrent();
                        LoadAllMesas();

                        var factura = new FacturaModel
                        {
                            IdPedido = idPedido,
                            Total = total,
                            SubTotal = subtotal,
                            Impuesto = impuesto
                        };

                        
                        int idfactura = facturarepo.Add(factura);

                        //showing factura to the user
                        ShowFacturaReportWrapper(idfactura, pedidosview);
                    }
                    catch(Exception ex)
                    {
                        pedidosview.Message = ex.Message;
                    }

                }
                else
                {
                    pedidosview.Message = "";
                }
            };


        }

        private async void ShowFacturaReportWrapper(int idfactura, object sender)
        {
            await ShowFacturaReportAsync(idfactura, sender);
        }


        private async Task ShowFacturaReportAsync(int idfactura, object sender)
        {
            IPedidosPendientesView pedidosview = null;
            IFacturaView facturaview = null;


            if (sender is IPedidosPendientesView pendingOrdersView)
            {
                pedidosview = pendingOrdersView;
                pedidosview.ShowWaitingMessage();
            }
            else if (sender is IFacturaView facturaView)
            {
                facturaview = facturaView;
                facturaview.ShowWaitingMessage();
            }

                        
            await Task.Run(() =>
            {
                FacturaModel factura = facturarepo.GetFacturaById(idfactura);
                var productos = pedidorepo.GetPedidoProductos(factura.IdPedido);

                if(pedidosview != null)
                {
                    pedidosview.InvokeForm((Action)(() =>
                    {
                        FacturaView report = new FacturaView(productos, factura);
                        pedidosview.HideWaitingMessage();
                        report.Show();
                    }));
                }
                else if(facturaview != null)
                {
                    facturaview.InvokeForm((Action)(() =>
                    {
                        FacturaView report = new FacturaView(productos, factura);
                        facturaview.HideWaitingMessage();
                        report.Show();
                    }));
                }
            });
        }



        private void SolicitarPedido(object sender, EventArgs e)
        {
            try
            {
                var cartRows = this.view.GetCartTableRows();

                if (cartRows.Count() == 0)
                {
                    view.Message = "Debe seleccionar productos";
                    return;
                }
                    

                var orderItems = new List<PedidoProductoModel>();

                foreach (var row in cartRows)
                {
                    var idProducto = (int)row.Cells["IdProductotbl"].Value;
                    var cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    var subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    var total = Convert.ToDecimal(row.Cells["Totaltbl"].Value);


                    var orderItem = new PedidoProductoModel
                    {
                        IdProducto = idProducto,
                        Cantidad = cantidad,
                        PrecioUnitario = subtotal,
                        PrecioTotal = total
                    };

                    new Common.ModelDataValidation().Validate(orderItem);
                    orderItems.Add(orderItem);
                }

                PedidoModel model = new PedidoModel();

                
                model.IdUsuario = idusuario;
                
                model.IdCliente = view.IdCliente;
                model.Cliente = view.NombreCliente;
                model.IdMesa = view.IdMesa;
                model.Impuesto = view.Impuesto;
                model.Total = Math.Round(view.Total,2);
                model.SubTotal = view.SubTotal;
                new Common.ModelDataValidation().Validate(model);

                if (view.isEdit)
                {

                }
                else
                {
                    pedidorepo.Add(model, orderItems);
                    view.Message = "Pedido Registrado Correctamente";
                    
                    view.ClearCartItems();
                    view.NombreCliente = "";
                    view.IdCliente = null;

                    
                }

                LoadAllMesas();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void BuscarCliente(object sender, EventArgs e)
        {
            IClienteControl clienteview = controlclientes.GetInstance();
            IClienteRepository clienterepo = new ClienteRepository(this.connectionString);
            IEnumerable<ClienteModel> clienteList = clienterepo.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(clienteList.ToList());

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = datatable;
            clienteview.SetClienteBindingSource(bindingSource);

            clienteview.ShowWindow();

            clienteview.GetSelectedClienteEvent += (ss, ee) =>
            {
                var currentRow = bindingSource.Current as DataRowView;
                if (currentRow != null)
                {
                    view.IdCliente = Convert.ToInt32(currentRow["IdCliente"]);
                    view.NombreCliente = currentRow["Nombre"].ToString();
                    clienteview.DisposeWindow();
                }



                
            };
        }

        private void LoadAllMesas()
        {
            IEnumerable<MesaModel> mesas = mesarepo.GetAll();
            view.SetMesaList(mesas);
        }

        private void LoadAllSalaBySucursal(int idsucursal)
        {
            IEnumerable<SalaModel> salas = salarepo.GetAllBySucursal(idsucursal);
            view.SetSalaComboBox(salas);
        }

        private void LoadAllCategoria()
        {
            IEnumerable<CategoriaModel> categorias = categoriarepo.GetAll();
            view.SetCategoriaComboBox(categorias);
        }

        private void LoadAllProducto()
        {
            IEnumerable<ProductoModel> productos = productorepo.GetAllNotExpired();
            view.SetProductoList(productos);
        }
    }
}
