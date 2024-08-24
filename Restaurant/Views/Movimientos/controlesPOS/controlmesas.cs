using Restaurant.Views.Interfaces.Movimientos.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos.POS_controles
{
    public partial class controlmesas : UserControl, IMesaControl
    {
        private bool _disponible;
        private bool _selected;

        public controlmesas()
        {
            InitializeComponent();

            lblnombre.Click += delegate { onSelectMesa?.Invoke(this, EventArgs.Empty); };
        }

        public int IdMesa { get; set; }
        public string Nombre { 
            get { return lblnombre.Text; }
            set { lblnombre.Text = value; }
        }
        public int Cantidad { 
            get { return Convert.ToInt32(lblcantidad.Text); }
            set { lblcantidad.Text = value.ToString(); }
        }

        public int IdSala {
            get; set;
        }
        public bool Disponible { 
            get { return _disponible; }
            set { 
                _disponible = value;

                if (!_disponible)
                {
                    lblnombre.BackColor = Color.Red;
                    this.Enabled = false;
                }
            }
        }

        public bool Selected { 
            get { return _selected; }
            set
            {
                _selected = value;
                if (_selected) { 

                    lblnombre.BackColor = Color.Blue;
                }
                else
                {
                    if (Disponible)
                    {
                        lblnombre.BackColor = Color.Green;
                    }
                    else
                    {
                        lblnombre.BackColor = Color.Red;
                        this.Enabled = false;
                    }
                }
            }
        }

        public event EventHandler onSelectMesa;
    }
}
