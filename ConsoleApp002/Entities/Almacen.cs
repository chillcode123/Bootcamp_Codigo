using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp002.Entities
{
    public class Almacen : BaseEntity
    {
        #region PROPIEDADES
        public string Detalle { get; set; } = string.Empty;

        public List<Producto>? ListaProductos { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Almacen(int id, string detalle)
        {
            Id = id;
            Detalle = detalle;
            ListaProductos = new List<Producto>();
            isActive = true;
            FechaCreacion = DateTime.Now;
        }
        #endregion


        //  Método para agregar un producto al almacén
        public void AgregarProducto(Producto producto)
        {
            if (ListaProductos == null)
            {
                ListaProductos = new List<Producto>();
            }
            ListaProductos.Add(producto);
        }
        // Método para eliminar un producto del almacén por ID
        public void EliminarProducto(int idProducto)
        {
            if (ListaProductos != null)
            {
                var producto = ListaProductos.FirstOrDefault(p => p.Id == idProducto);
                if (producto != null)
                {
                    ListaProductos.Remove(producto);
                }
            }
        }
        // Método para obtener un producto por ID
        public Producto? ObtenerProductoPorId(int idProducto)
        {
            if (ListaProductos != null)
            {
                return ListaProductos.FirstOrDefault(p => p.Id == idProducto);
            }
            return null;
        }
        // Método para obtener todos los productos del almacén
        public List<Producto> ObtenerTodosLosProductos()
        {
            return ListaProductos!;
        }
        





    }
}
