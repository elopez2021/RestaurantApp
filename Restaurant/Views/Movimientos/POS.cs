using Restaurant.Models;
using Restaurant.Views.Interfaces.Movimientos;
using Restaurant.Views.Interfaces.Movimientos.UserControls;
using Restaurant.Views.Movimientos.POS_controles;
using Restaurant.Views.Movimientos.POS_Paneles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos
{
    public partial class POS : Form, IPOSView
    {

        public POS()
        {
            InitializeComponent();
            btnbuscarcliente.Click += delegate { BuscarCliente?.Invoke(this, EventArgs.Empty); };

            cmbsalas.SelectedValueChanged += ShowMesaBySala;
            cmbcategoria.SelectedValueChanged += ShowProductoByCategoria;
            txtsearch.TextChanged += txtSearch_TextChanged;

            btnborrar.Click += DeleteProducto;
            btnlimpiarcliente.Click += delegate
            {
                NombreCliente = "";
                IdCliente = null;
            };

            btnsolicitar.Click += delegate { 
                SolicitarPedido?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnpendientes.Click += delegate
            {
                ShowPedidosPendientes?.Invoke(this, EventArgs.Empty);
            };

            btnfacturas.Click += delegate { ShowFacturas?.Invoke(this, EventArgs.Empty); };

        }

        public string ProductoSearch { 
            get { return txtsearch.Text; }
            set { txtsearch.Text = value; }
        }
        public int? IdCliente { get; set; }
        public string NombreCliente
        {
            get { return txtcliente.Text; }
            set { 
                txtcliente.Text = value; 

                txtcliente.Enabled = (value == "" ? true : false); 
            }
        }
        public decimal Total { 
            get {
                string soloNumeros = lbltotal.Text.Replace("RD$", "").Trim();
                return decimal.Parse(soloNumeros, CultureInfo.InvariantCulture);
            }
            set { lbltotal.Text = $"RD${value.ToString("N2")}"; }
        }
        public decimal SubTotal {
            get
            {
                string soloNumeros = lblsubtotal.Text.Replace("RD$", "").Trim();
                return decimal.Parse(soloNumeros, CultureInfo.InvariantCulture);
            }
            set { lblsubtotal.Text = $"RD${value.ToString("N2")}"; }
        }
        public decimal Impuesto {
            get
            {
                string soloNumeros = lblimpuesto.Text.Replace("RD$", "").Trim();
                return decimal.Parse(soloNumeros, CultureInfo.InvariantCulture);
            }
            set { lblimpuesto.Text = $"RD${value.ToString("N2")}"; }
        }

        public int? IdMesa { get; set; }
        public string Message { get; set; }
        public bool isEdit { get; set; }

        public event EventHandler ShowFacturas;
        public event EventHandler ShowPedidosPendientes;
        public event EventHandler BuscarCliente;
        public event EventHandler SolicitarPedido;
        public event EventHandler BorrarItems;
        public event EventHandler onSelectProducto;


        private void DeleteProducto(object sender, EventArgs e)
        {
            if (carttable.SelectedRows.Count > 0)
            {
                int rowIndex = carttable.SelectedRows[0].Index;
                var selectedRow = carttable.SelectedRows[0];
                int selectedProductId = Convert.ToInt32(selectedRow.Cells["IdProductotbl"].Value);
                int cantidadselected = Convert.ToInt32(selectedRow.Cells["Cantidad"].Value);
                bool esproductofinal = (bool)selectedRow.Cells["EsProductoFinaltbl"].Value;

                decimal subtotal = decimal.Parse(selectedRow.Cells["Subtotal"].Value.ToString());
                decimal impuesto = Math.Round(subtotal * (decimal.Parse(selectedRow.Cells["Impuestotbl"].Value.ToString()) / 100m), 2);
                decimal total = decimal.Parse(selectedRow.Cells["Totaltbl"].Value.ToString());

               
               


                if (!esproductofinal)
                {
                    foreach (var control in panelproducto.Controls)
                    {
                        if (control is controlproductos wdg)
                        {
                            if (wdg.IdProducto == selectedProductId)
                            {
                                wdg.CantidadMaxima += cantidadselected;
                                break;
                            }
                        }
                    }
                }

                Total -= total;
                Impuesto -= impuesto;
                SubTotal -= subtotal;

                carttable.Rows.RemoveAt(rowIndex);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach(var item in panelproducto.Controls)
            {
                var producto = (controlproductos)item;
                producto.Visible = producto.Nombre.ToLower().Contains(txtsearch.Text.Trim().ToLower());
            }
        }


        private void ShowProductoByCategoria(object sender, EventArgs e)
        {
            object selectedValue = cmbcategoria.SelectedValue;
            int idcategoria;

            if (selectedValue is KeyValuePair<int, string> selectedPair)
            {
                idcategoria = selectedPair.Key;
            }
            else if (selectedValue is int selectedInt)
            {
                idcategoria = selectedInt;
            }
            else
            {
                idcategoria = -1;
            }

            foreach (var item in panelproducto.Controls)
            {
                var producto = (controlproductos)item;
                if(idcategoria == -1)
                {
                    producto.Visible = true;
                }
                else
                {
                    producto.Visible = producto.IdCategoria == idcategoria;
                }
            }
        }

        private void ShowMesaBySala(object sender, EventArgs e)
        {
            if (cmbsalas.SelectedValue == null)
            {
                return;
            }
            object selectedValue = cmbsalas.SelectedValue;
            int idsala;

            if (selectedValue is KeyValuePair<int, string> selectedPair)
            {
                idsala = selectedPair.Key;
            }
            else if (selectedValue is int selectedInt)
            {
                idsala = selectedInt;
            }
            else
            {
                idsala = -1;
            }


            foreach (var item in panelmesas.Controls)
            {
                var mesa = (controlmesas)item;
                if(idsala == -1)
                {
                    mesa.Visible = true;
                }
                else
                {
                    mesa.Visible = mesa.IdSala == idsala;
                }
            }           
        }

        public DataGridViewRow[] GetCartTableRows()
        {
            return carttable.Rows.Cast<DataGridViewRow>().ToArray();
        }

        
         public void SetProductoList(IEnumerable<ProductoModel> productoList)
         {
            
            panelproducto.Controls.Clear();

            foreach (ProductoModel producto in productoList)
            {
                IProductoControl productoctrl = new controlproductos()
                {
                    IdProducto = producto.IdProducto,
                    CodigoProducto = producto.CodigoProducto,
                    IdCategoria = (int)producto.IdCategoria,
                    Nombre = producto.Nombre,
                    Precio = (decimal)producto.PrecioVenta,
                    Impuesto = producto.PorcentajeImpuesto,
                    EsProductoFinal = producto.EsProductoFinal,
                    CantidadMaxima = producto.Existencia,
                    Imagen = producto.RutaFoto                    
                };
                
                panelproducto.Controls.Add((Control)productoctrl);

               

                productoctrl.onSelectProducto += (ss, ee) =>
                {                    
                    var wdg = (controlproductos)ss;
                    AddToCart(wdg);                  
                    
                    UpdateCartTotals();
                };
               

            }
        }


        public void AddToCart(controlproductos wdg)
        {
            bool productoEncontrado = false;

           

            foreach (DataGridViewRow item in carttable.Rows)
            {
                if (item.Cells["NoProducto"].Value.ToString() == wdg.CodigoProducto)
                {
                    item.Cells["Cantidad"].Value = int.Parse(item.Cells["Cantidad"].Value.ToString()) + 1;
                    item.Cells["Subtotal"].Value = Math.Round(
                        int.Parse(item.Cells["Cantidad"].Value.ToString()) *
                        decimal.Parse(item.Cells["Precio"].Value.ToString()), 2);

                  


                    decimal impuesto = decimal.Parse(item.Cells["Impuestotbl"].Value.ToString()) / 100m;
                    decimal subtotal = decimal.Parse(item.Cells["Subtotal"].Value.ToString());
                    decimal total = Math.Round(subtotal + (subtotal * impuesto), 2);
                    item.Cells["Totaltbl"].Value = total;

                    item.Cells["Totaltbl"].Style.Format = "N2";

                    productoEncontrado = true;
                    break;
                    //precioconimpuesto = preciounitario + (preciounitario * (impuesto / 100))
                }
            }

            if (!productoEncontrado)
            {

                carttable.Rows.Add(new object[]
                {
                            wdg.IdProducto,
                            wdg.CodigoProducto,
                            wdg.Nombre,
                            Math.Round(wdg.Precio,2),
                            1,
                            Math.Round(wdg.Precio,2),
                            Math.Round(wdg.Precio + (wdg.Precio * (wdg.Impuesto / 100m)),2),
                            Math.Round(wdg.Impuesto,2),
                            wdg.EsProductoFinal
                });
            }

            if (!wdg.EsProductoFinal) wdg.CantidadMaxima--;
        }
            
       

        private void UpdateCartTotals()
        {
            decimal totalAmount = 0m;
            decimal impuestoAmount = 0m;
            decimal subtotalAmount = 0m;

            foreach (DataGridViewRow row in carttable.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    decimal subtotal = decimal.Parse(row.Cells["Subtotal"].Value.ToString());
                    decimal impuesto = decimal.Parse(row.Cells["Impuestotbl"].Value.ToString()) / 100m;
                    decimal total = decimal.Parse(row.Cells["Totaltbl"].Value.ToString());

                    subtotalAmount += subtotal;
                    impuestoAmount += subtotal * impuesto;
                    totalAmount += total;
                }
            }

            SubTotal = Math.Round(subtotalAmount, 2);
            Impuesto = Math.Round(impuestoAmount,2);
            Total = Math.Round(totalAmount,2);
        }

        void IPOSView.SetCategoriaComboBox(IEnumerable<CategoriaModel> categoriaList)
        {
            var list = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(-1, "Todas")
            };
            list.AddRange(categoriaList.ToDictionary(s => s.IdCategoria, s => s.Nombre));
            cmbcategoria.DataSource = new BindingSource(list, null);
            cmbcategoria.DisplayMember = "Value";
            cmbcategoria.ValueMember = "Key";


            //cmbcategoria.SelectedValue = -1;
        }

        void IPOSView.SetMesaList(IEnumerable<MesaModel> mesaList)
        {

            panelmesas.Controls.Clear();

            foreach (MesaModel mesa in mesaList)
            {
                controlmesas mesactrl = new controlmesas();
                mesactrl.IdMesa = mesa.IdMesa;
                mesactrl.Nombre = mesa.Nombre;
                mesactrl.Cantidad = mesa.CantidadPersona;
                mesactrl.IdSala = (int)mesa.IdSala;
                mesactrl.Disponible = mesa.Disponible;

                if (!mesa.Disponible) mesactrl.Enabled = false;

                mesactrl.onSelectMesa += (ss, ee) =>
                {
                    var wdg = (controlmesas)ss;
                    wdg.Selected = true;
                    IdMesa = wdg.IdMesa;

                    foreach (controlmesas mesad in panelmesas.Controls.OfType<controlmesas>())
                    {
                        if (mesad.IdMesa != IdMesa)
                        {
                            mesad.Selected = false;
                        }
                    }
                };

                panelmesas.Controls.Add((Control)mesactrl);
            }
        }

        void IPOSView.SetSalaComboBox(IEnumerable<SalaModel> salaList)
        {

            var salaListWithNewOption = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(-1, "Todas")
            };

            salaListWithNewOption.AddRange(salaList.ToDictionary(s => s.IdSala, s => s.Nombre));

           
            cmbsalas.DataSource = new BindingSource(salaListWithNewOption, null);
            cmbsalas.DisplayMember = "Value";
            cmbsalas.ValueMember = "Key";

            //cmbsalas.SelectedValue = -1;
        }

        public void ClearCartItems()
        {
            carttable.Rows.Clear();
        }
    }
}
