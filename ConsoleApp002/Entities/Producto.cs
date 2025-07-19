using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp002.Entities
{
    public class Producto : BaseEntity
    {
        #region PROPIEDADES
        public string Categoria { get; set; } = string.Empty;
        public string SubCategoria { get; set; } = string.Empty;
        public int EdadRecomendada { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string UnidadVenta { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        public int AlmacenId { get; set; }

        #endregion

        #region CONSTRUCTOR
        public Producto(int id, string categoria, string subcategoria, int edad, string descripcion, string unidadVenta, int stock, decimal precio, int almacenId)
        {
            Id = id;
            Categoria = categoria;
            SubCategoria = subcategoria;
            EdadRecomendada = edad;
            Descripcion = descripcion;
            UnidadVenta = unidadVenta;
            Stock = stock;
            Precio = precio;
            AlmacenId = almacenId;
        }

        #endregion

        #region METODOS Y FUNCIONES
        //  Método para obtener un producto por ID
        public Producto? ObtenerProductoPorId(int idProducto)
        {
            if (Id == idProducto)
            {
                return this;
            }
            return null;
        }



        //  Método para actualizar el stock del producto
        public void ActualizarStock(int nuevoStock)
        {
            if (nuevoStock >= 0)
            {
                Stock = nuevoStock;
            }
            else
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }
        }

        // Método para actualizar el producto

        //  Metodo para obtener la informacion del producto como cadena
        public override string ToString()
        {
            return $"Id: {Id}, Categoría: {Categoria}, Subcategoria: {SubCategoria}, Edad Indicada: {EdadRecomendada}, Descripción: {Descripcion}, Unidad de Venta: {UnidadVenta}, Stock: {Stock}, Precio: {Precio:C}";
        }

        #endregion


    }
}
