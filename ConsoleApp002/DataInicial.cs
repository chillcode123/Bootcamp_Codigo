using ConsoleApp002.Entities;

namespace ConsoleApp002
{
    public class DataInicial
    {
        public static Tuple<List<Almacen>,List<Producto>> Cargar()
        {
            List<Almacen> MisAlmacenes = new List<Almacen>();

            for (int i = 0; i < 10; i++)
            {
                Almacen NuevoAlmacen = new Almacen(i + 1, "Almacen " + i + 1);
                MisAlmacenes.Add(NuevoAlmacen);
            }

            List<Producto> MisProductos = new List<Producto>();

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                string categoria;
                string subcategoria;
                int edad;
                string descripcion;
                string unidadVenta;
                int almacenId = random.Next(1, 11);

                if (random.Next() < 0.2)
                {
                    categoria = "Cuadernos";
                    if (i % 2 == 0)
                    {
                        subcategoria = "Rayados";
                    }
                    else
                    {
                        subcategoria = "Lisos";
                    }

                    edad = 3;
                    descripcion = "Cuaderno " + (i + 1);
                    unidadVenta = "Unidad";
                    
                }
                else if (random.Next() < 0.4)
                {
                    categoria = "Pinturas";
                    if (i % 2 == 0)
                    {
                        subcategoria = "Acuarelas";
                    }
                    else
                    {
                        subcategoria = "Tempera";
                    }
                    edad = 4;
                    descripcion = "Pintura " + (i + 1);
                    unidadVenta = "Paquete";
                }
                else if (random.Next() < 0.6)
                {
                    categoria = "Lapiceros";
                    if (i % 2 == 0)
                    {
                        subcategoria = "Gel";
                    }
                    else
                    {
                        subcategoria = "Tinta";
                    }

                    edad = 11;
                    descripcion = "Lapicero " + (i + 1);
                    unidadVenta = "Unidad";
                }
                else if (random.Next() < 0.8)
                {
                    categoria = "Plumones";
                    if (i % 2 == 0)
                    {
                        subcategoria = "Punta Gruesa";
                    }
                    else
                    {
                        subcategoria = "Punta Fina";
                    }

                    edad = 6;
                    descripcion = "Plumone " + (i + 1);
                    unidadVenta = "Paquete";
                }
                else
                {
                    categoria = "Escuadras";
                    if (i % 2 == 0)
                    {
                        subcategoria = "Plastico";
                    }
                    else
                    {
                        subcategoria = "Metal";
                    }
                    edad = 10;
                    descripcion = "Escuadra " + (i + 1);
                    unidadVenta = "Paquete";
                }


                Producto NuevoProducto = new Producto(i + 1, categoria, subcategoria, edad, descripcion, unidadVenta, i * 100, i * 100, almacenId);
                MisProductos.Add(NuevoProducto);

                //  Actualizar el almacén con el nuevo producto 
                var almacen = MisAlmacenes.FirstOrDefault(a => a.Id == almacenId);
                if (almacen != null)
                {
                    almacen.AgregarProducto(NuevoProducto);
                }
            }

            return Tuple.Create(MisAlmacenes, MisProductos);
        }
    }
}
