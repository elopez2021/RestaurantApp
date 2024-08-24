using Restaurant.Views.Interfaces.Movimientos.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos.POS_Paneles
{
    public partial class controlproductos : UserControl, IProductoControl
    {
        private string _rutafoto;
        private int? _cantidadmaxima = 0;

        public controlproductos()
        {
            InitializeComponent();

            boxfoto.Click += delegate { onSelectProducto?.Invoke(this, EventArgs.Empty); };
        }

        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio {
            get { return decimal.TryParse(lblprecio.Text, out decimal resultado) ? resultado : 0m; }
            set { lblprecio.Text = value.ToString("F2"); }
        }
        public string Nombre { 
            get { return lblnombre.Text; }
            set { lblnombre.Text = value; }
        }
        public string Imagen { 
            get { return _rutafoto; }
            set {
                LoadImage(value);
                _rutafoto = value;
            }
        }

        public decimal Impuesto { get; set; }
        public int? CantidadMaxima { 
            get { return _cantidadmaxima; }
            set
            {
                _cantidadmaxima = value;

                if (EsProductoFinal)
                {
                    this.Enabled = true;
                }
                else
                {
                    if (_cantidadmaxima <= 0)
                    {
                        _cantidadmaxima = 0;
                        this.Enabled = false;
                    }
                    else
                    {
                        this.Enabled = true;
                    }
                }

            }
        }

        public bool EsProductoFinal { get; set; }

        public event EventHandler onSelectProducto;

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
    }
}
