using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Restaurant.Models
{
    public class ProductoModel
    {
        private DateTime? _fechaexpiracion;
        private DateTime? _fechaelaboracion;

        [Key]
        [Browsable(false)]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El código del producto es requerido.")]
        [StringLength(50, ErrorMessage = "El código del producto no puede exceder los 50 caracteres.")]
        public string CodigoProducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La categoría del producto es requerida.")]
        [Browsable(false)]
        public int? IdCategoria { get; set; }
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El precio de venta es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor o igual a 0.")]
        public decimal? PrecioVenta { get; set; }

        [Required(ErrorMessage = "El impuesto es requerido.")]
        [Browsable(false)]
        public int? IdImpuesto { get; set; }
        public string Impuesto { get; set; }

        [Browsable(false)]
        public decimal PorcentajeImpuesto { get; set; }
        
        [Browsable(false)]
        public int? IdProveedor { get; set; }
        public string Proveedor { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de compra debe ser mayor o igual a 0.")]
        public decimal? PrecioCompra { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La existencia debe ser mayor o igual a 0.")]
        public int? Existencia { get; set; }

        [StringLength(50, ErrorMessage = "El número de lote no puede exceder los 50 caracteres.")]
        public string NoLote { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo debe ser mayor o igual a 0.")]
        public int? StockMinimo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock máximo debe ser mayor o igual al stock mínimo.")]
        [CustomValidation(typeof(ProductoModel), nameof(ValidateStockMaximo))]
        public int? StockMaximo { get; set; }

        public DateTime? FechaElaboracion { 
            get
            {
                if (EsProductoFinal) return null;
                return _fechaelaboracion;
            }
            set
            {
                _fechaelaboracion = value;
            }
        }

        [CustomValidation(typeof(ProductoModel), nameof(ValidateFechaExpiracion))]
        public DateTime? FechaExpiracion { 
            get
            {
                if (EsProductoFinal) return null;
                return _fechaexpiracion;
            }
            set
            {
                _fechaexpiracion = value;
            }
        }

        [StringLength(50, ErrorMessage = "El código de barra no puede exceder los 50 caracteres.")]
        [Required(ErrorMessage = "El código de barra es requerido.")]
        public string CodigoDeBarra { get; set; }

        [Required(ErrorMessage = "La foto del producto es requerida.")]
        [StringLength(255, ErrorMessage = "La ruta de la foto no puede exceder los 255 caracteres.")]
        public string RutaFoto { get; set; }

        public decimal? Descuento { get; set; }

        public bool Estado { get; set; } = true;

        [Required(ErrorMessage = "Debe especificar si el producto es final.")]
        [CustomValidation(typeof(ProductoModel), nameof(ValidateCamposProductoFinal))]
        public bool EsProductoFinal { get; set; }

        public static ValidationResult ValidateStockMaximo(int? stockMaximo, ValidationContext context)
        {
            var instance = context.ObjectInstance as ProductoModel;
            if (instance.StockMinimo.HasValue && stockMaximo.HasValue && stockMaximo < instance.StockMinimo)
            {
                return new ValidationResult("El stock máximo debe ser mayor o igual al stock mínimo.");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateFechaExpiracion(DateTime? fechaExpiracion, ValidationContext context)
        {
            var instance = context.ObjectInstance as ProductoModel;
            if (instance != null)
            {
                if (instance.FechaElaboracion.HasValue && fechaExpiracion.HasValue)
                {
                    if (fechaExpiracion < instance.FechaElaboracion)
                    {
                        return new ValidationResult("La fecha de expiración no puede ser anterior a la fecha de elaboración.");
                    }
                }
            }
            return ValidationResult.Success;
        }

        [CustomValidation(typeof(ProductoModel), nameof(ValidateCamposProductoFinal))]
        public static ValidationResult ValidateCamposProductoFinal(bool esProductoFinal, ValidationContext context)
        {
            var producto = context.ObjectInstance as ProductoModel;

            if (producto != null && !esProductoFinal)
            {
                        // Dictionary to map field names to their values
                var fields = new Dictionary<string, object>
                {
                    { nameof(producto.PrecioCompra), producto.PrecioCompra },
                    { nameof(producto.Existencia), producto.Existencia },
                    { nameof(producto.NoLote), producto.NoLote },
                    { nameof(producto.StockMinimo), producto.StockMinimo },
                    { nameof(producto.StockMaximo), producto.StockMaximo },
                    { nameof(producto.FechaElaboracion), producto.FechaElaboracion },
                    { nameof(producto.FechaExpiracion), producto.FechaExpiracion },
                    { nameof(producto.CodigoDeBarra), producto.CodigoDeBarra }
                };

                // Check each field and build error message
                var missingFields = fields
                    .Where(field => field.Value == null || (field.Value is string str && string.IsNullOrWhiteSpace(str)))
                    .Select(field => field.Key);

                if (missingFields.Any())
                {
                    var fieldNames = string.Join(", ", missingFields);
                    return new ValidationResult($"Los siguientes campos deben ser completados si el producto no es final: {fieldNames}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}