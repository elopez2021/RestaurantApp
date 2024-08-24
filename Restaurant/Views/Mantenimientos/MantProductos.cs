using Restaurant.Models;
using Restaurant.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views
{
    public partial class MantProductos : Form, IProductoView
    {
        private string rutaFoto;
        public MantProductos()
        {
            InitializeComponent();

            btnguardar.Click += delegate {
                GuardarEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btneliminar.Enabled = false;
            };
            btnlimpiar.Click += delegate { LimpiarEvent?.Invoke(this, EventArgs.Empty); btneliminar.Enabled = false; };
            btneliminar.Click += delegate {

                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas desactivar este registro?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    btneliminar.Enabled = false;
                }

            };
            table.CellClick += delegate { EditarEvent?.Invoke(this, EventArgs.Empty); btneliminar.Enabled = true; };

            btnselectfoto.Click += delegate { SeleccionarFotoEvent?.Invoke(this, EventArgs.Empty);};
            
        }

        public event EventHandler LimpiarEvent;
        public event EventHandler GuardarEvent;
        public event EventHandler EditarEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SeleccionarFotoEvent;

        public int IdProducto { get; set; }
        public string CodigoProducto {
            get { return txtcod.Text; }
            set { txtcod.Text = value; }
        }
        public string Nombre { 
            get { return txtnomb.Text; }
            set { txtnomb.Text = value; }
        }
        public int? IdCategoria {
            get { return cmbcategoria.SelectedValue != null ? Convert.ToInt32(cmbcategoria.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbcategoria.SelectedValue = selected ?? -1; }
        }
        public decimal? PrecioVenta {
            get
            {
                return decimal.TryParse(txtventa.Text, out decimal result) ? result : (decimal?)null;
            }
            set
            {
                txtventa.Text = value.HasValue ? value.Value.ToString("F2") : string.Empty;
            }
        }
        public int? IdImpuesto {
            get { return cmbimpuesto.SelectedValue != null ? Convert.ToInt32(cmbimpuesto.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbimpuesto.SelectedValue = selected ?? -1; }
        }
        public int? IdProveedor {
            get { return cmbproveedor.SelectedValue != null ? Convert.ToInt32(cmbproveedor.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbproveedor.SelectedValue = selected ?? -1; }
        }
        public decimal? PrecioCompra {
            get
            {
                return decimal.TryParse(txtcompra.Text, out decimal result) ? result : (decimal?)null;
            }
            set
            {
                txtcompra.Text = value.HasValue ? value.Value.ToString("F2") : string.Empty;
            }
        }
        public decimal? Descuento {
            get
            {
                return decimal.TryParse(txtdescuento.Text, out decimal result) ? result : (decimal?)null;
            }
            set
            {
                txtdescuento.Text = value.HasValue ? value.Value.ToString("F2") : string.Empty;
            }
        }
        public int? Existencia {
            get
            {
                if (int.TryParse(txtexist.Text, out int result))
                {
                    return result;
                }
                return null;
            }
            set
            {
                txtexist.Text = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        public string NoLote
        {
            get { return txtlote.Text; }
            set { txtlote.Text = value; }
        }
        public int? StockMinimo {
            get
            {
                if (int.TryParse(txtstockmin.Text, out int result))
                {
                    return result;
                }
                return null;
            }
            set
            {
                txtstockmin.Text = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        public int? StockMaximo {
            get
            {
                if (int.TryParse(txtstockmax.Text, out int result))
                {
                    return result;
                }
                return null;
            }
            set
            {
                txtstockmax.Text = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        public DateTime? FechaElaboracion {
            get
            {

                return dateelabo.Value == default ? (DateTime?)null : dateelabo.Value;
            }
            set
            {
                dateelabo.Value = value.HasValue &&
                          value.Value >= dateelabo.MinDate &&
                          value.Value <= dateelabo.MaxDate
                          ? value.Value
                          : dateelabo.MinDate;
            }
        }
        public DateTime? FechaExpiracion
        {
            get
            {
                return dateexpira.Value == default(DateTime) ? (DateTime?)null : dateexpira.Value;
            }
            set
            {
                dateexpira.Value = value.HasValue &&
                           value.Value >= dateexpira.MinDate &&
                           value.Value <= dateexpira.MaxDate
                           ? value.Value
                           : dateexpira.MinDate;
            }
        }

        public string CodigoDeBarra
        {
            get { return txtbarra.Text; }
            set { txtbarra.Text = value; }
        }
        public string RutaFoto {
            get { return rutaFoto; }
            set
            {
                rutaFoto = value;
                if (string.IsNullOrEmpty(value))
                {
                    boxfoto.Image = null;
                }
                else
                {
                    LoadImage(value);
                }
            }
        }
        public bool EsProductoFinal
        {
            get { return cmbtipoproducto.SelectedIndex == 1 ? true : false; }
            set { cmbtipoproducto.SelectedIndex = (value ? 1 : 0); }
        }
        public bool isEdit { get; set; }
        public string Message { get; set; }

        private void MantProductos_Load(object sender, EventArgs e)
        {
            cmbtipoproducto.Focus();
        }

        private void txtcod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtnomb.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbcategoria.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void combcateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtcompra.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtcompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtventa.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtexist.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtexist_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtstockmin.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtstockmax.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbimpuesto.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void cmbimpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtdescuento.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtlote.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtlote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                dateelabo.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtbarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                btnselectfoto.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dateelabo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                dateexpira.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void dateexpira_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbproveedor.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void comboprovee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtbarra.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void cmbtipoproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtipoproducto.SelectedIndex == 1)
            {
                txtstockmin.Enabled = false;
                txtstockmax.Enabled = false;
                txtexist.Enabled = false;
                txtlote.Enabled = false;
                txtcompra.Enabled = false;
                dateelabo.Enabled = false;
                dateexpira.Enabled = false;
                cmbproveedor.Enabled = false;
            }
            else
            {
                txtstockmin.Enabled = true;
                txtstockmax.Enabled = true;
                txtexist.Enabled = true;
                txtlote.Enabled = true;
                txtcompra.Enabled = true;
                dateelabo.Enabled = true;
                dateexpira.Enabled = true;
                cmbproveedor.Enabled = true;
            }

        }

        public void SetProductoListBindingSource(BindingSource productoList)
        {
            table.DataSource = productoList;
        }

        void IProductoView.SetCategoriaComboBox(IEnumerable<CategoriaModel> categorias)
        {
            var categoriaDictionary = categorias.ToDictionary(s => s.IdCategoria, s => s.Nombre);
            cmbcategoria.DataSource = new BindingSource(categoriaDictionary, null);
            cmbcategoria.DisplayMember = "Value";
            cmbcategoria.ValueMember = "Key";
            cmbcategoria.SelectedValue = -1;
        }

        void IProductoView.SetImpuestoComboBox(IEnumerable<ImpuestoModel> impuestos)
        {
            var impuestoDictionary = impuestos.ToDictionary(s => s.IdImpuesto, s => s.Nombre);
            cmbimpuesto.DataSource = new BindingSource(impuestoDictionary, null);
            cmbimpuesto.DisplayMember = "Value";
            cmbimpuesto.ValueMember = "Key";
            cmbimpuesto.SelectedValue = -1;
        }

        void IProductoView.SetProveedorComboBox(IEnumerable<ProveedorModel> proveedores)
        {
            var proveedorDictionary = proveedores.ToDictionary(s => s.IdProveedor, s => s.NombreProveedor);
            cmbproveedor.DataSource = new BindingSource(proveedorDictionary, null);
            cmbproveedor.DisplayMember = "Value";
            cmbproveedor.ValueMember = "Key";
            cmbproveedor.SelectedValue = -1;
        }


        public void LoadImage(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                MessageBox.Show("No se proporcionó una ruta de archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                boxfoto.Image = Image.FromFile(filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbtipoproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtcod.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }
    }
}
