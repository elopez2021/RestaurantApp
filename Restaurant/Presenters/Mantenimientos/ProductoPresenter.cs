using Restaurant.Models;
using Restaurant.Presenters.Common;
using Restaurant.Repositories.Interfaces;
using Restaurant.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Presenters
{
    internal class ProductoPresenter
    {
        private IProductoView view;
        private IProductoRepository productorepo;
        private ICategoriaRepository categoriarepo;
        private IProveedorRepository proveedorrepo;
        private IImpuestoRepository impuestorepo;
        private BindingSource productoBindingSource;

        public ProductoPresenter(IProductoView view, IProductoRepository productorepo, ICategoriaRepository categoriarepo, IProveedorRepository proveedorrepo, IImpuestoRepository impuestorepo)
        {
            this.view = view;
            this.productorepo = productorepo;
            this.categoriarepo = categoriarepo;
            this.proveedorrepo = proveedorrepo;
            this.impuestorepo = impuestorepo;

            productoBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedProducto;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;
            this.view.SeleccionarFotoEvent += SeleccionarFoto;

            this.view.SetProductoListBindingSource(productoBindingSource);
            
            LoadAllProductoList();
            LoadAllProveedor();
            LoadAllCategoria();
            LoadAllImpuesto();
        }

        private void LoadAllImpuesto()
        {
            IEnumerable<ImpuestoModel> impuesto = impuestorepo.GetAll();
            view.SetImpuestoComboBox(impuesto);
        }

        private void LoadAllCategoria()
        {
            IEnumerable<CategoriaModel> categoria = categoriarepo.GetAll();
            view.SetCategoriaComboBox(categoria);
        }

        private void LoadAllProveedor()
        {
            IEnumerable<ProveedorModel> proveedor = proveedorrepo.GetAll();
            view.SetProveedorComboBox(proveedor);
        }

        private void LoadAllProductoList()
        {
            IEnumerable<ProductoModel> producto = productorepo.GetAll();
            DataTable datatable = DataTableConverter.ConvertToDataTable(producto.ToList());

            productoBindingSource.DataSource = datatable;
        }

        private void SeleccionarFoto(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
                openFileDialog.Title = "Selecciona una imagen";

                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    view.RutaFoto = filePath;
                    
                }
            }
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new ProductoModel
            {
                IdProducto = view.IdProducto,
                CodigoProducto = view.CodigoProducto,
                Nombre = view.Nombre,
                IdCategoria = view.IdCategoria,
                PrecioVenta = view.PrecioVenta,
                IdImpuesto = view.IdImpuesto,
                IdProveedor = view.IdProveedor,
                PrecioCompra = view.PrecioCompra,
                Existencia = view.Existencia,
                NoLote = view.NoLote,
                StockMinimo = view.StockMinimo,
                StockMaximo = view.StockMaximo,
                FechaElaboracion = view.FechaElaboracion,
                FechaExpiracion = view.FechaExpiracion,
                CodigoDeBarra = view.CodigoDeBarra,
                RutaFoto = view.RutaFoto,
                Descuento = view.Descuento,
                EsProductoFinal = view.EsProductoFinal
            };

            if (model.Descuento == null)
            {
                model.Descuento = 0.00m;
            }

            try
            {
                new Common.ModelDataValidation().Validate(model);


                //string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //string imageFolder = Path.Combine(projectDirectory, "ProductImages");

                string imageFolder = @"C:\ProductImages";


                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }
                
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.RutaFoto)}";
                string destPath = Path.Combine(imageFolder, fileName);

                string previousImagePath = "";

                if (view.isEdit)
                {
                    previousImagePath = model.RutaFoto;

                    File.Copy(model.RutaFoto, destPath, true);
                    model.RutaFoto = destPath;

                    productorepo.Update(model);
                    view.Message = "Producto Editado Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    File.Copy(model.RutaFoto, destPath, true);
                    model.RutaFoto = destPath;

                    
                    productorepo.Add(model);
                    view.Message = "Producto Añadido Satisfactoriamente";
                }
                
                   
                LoadAllProductoList();
                CleanviewFields();

                if (view.isEdit)
                {
                    if (File.Exists(previousImagePath))
                    {
                        File.Delete(previousImagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.CodigoProducto = string.Empty;
            view.Nombre = string.Empty;
            view.IdCategoria = null;
            view.PrecioVenta = null;
            view.IdImpuesto = null;
            view.IdProveedor = null;
            view.PrecioCompra = null;
            view.Existencia = null;
            view.NoLote = string.Empty;
            view.StockMinimo = null;
            view.StockMaximo = null;
            view.FechaElaboracion = null;
            view.FechaExpiracion = null;
            view.CodigoDeBarra = string.Empty;
            view.RutaFoto = string.Empty;
            view.Descuento = null;
            view.EsProductoFinal = false;
        }

        private void Eliminar(object sender, EventArgs e)
        {
            try
            {
                this.productorepo.Delete(this.view.IdProducto);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllProductoList();
            CleanviewFields();
        }

        private void LoadSelectedProducto(object sender, EventArgs e)
        {
            var currentRow = productoBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdProducto = Convert.ToInt32(currentRow["IdProducto"]);
                view.CodigoProducto = currentRow["CodigoProducto"].ToString();
                view.Nombre = currentRow["Nombre"].ToString();
                view.IdCategoria = Convert.ToInt32(currentRow["IdCategoria"]);
                view.PrecioVenta = Convert.ToDecimal(currentRow["PrecioVenta"]);
                view.IdImpuesto = Convert.ToInt32(currentRow["IdImpuesto"]);
                view.IdProveedor = currentRow["IdProveedor"] != DBNull.Value ? (int?)Convert.ToInt32(currentRow["IdProveedor"]) : null;
                view.PrecioCompra = currentRow["PrecioCompra"] != DBNull.Value ? (decimal?)Convert.ToDecimal(currentRow["PrecioCompra"]) : null;
                view.Existencia = currentRow["Existencia"] != DBNull.Value ? (int?)Convert.ToInt32(currentRow["Existencia"]) : null;
                view.NoLote = currentRow["NoLote"].ToString();
                view.StockMinimo = currentRow["StockMinimo"] != DBNull.Value ? (int?)Convert.ToInt32(currentRow["StockMinimo"]) : null;
                view.StockMaximo = currentRow["StockMaximo"] != DBNull.Value ? (int?)Convert.ToInt32(currentRow["StockMaximo"]) : null;
                view.FechaElaboracion = currentRow["FechaElaboracion"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(currentRow["FechaElaboracion"]) : null;
                view.FechaExpiracion = currentRow["FechaExpiracion"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(currentRow["FechaExpiracion"]) : null;
                view.CodigoDeBarra = currentRow["CodigoDeBarra"].ToString();
                view.RutaFoto = currentRow["RutaFoto"].ToString();
                view.Descuento = currentRow["Descuento"] != DBNull.Value ? (decimal?)Convert.ToDecimal(currentRow["Descuento"]) : null;
                view.EsProductoFinal = Convert.ToBoolean(currentRow["EsProductoFinal"]);

                view.isEdit = true;
            }

        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }

    }
}
