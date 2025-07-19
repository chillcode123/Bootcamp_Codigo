using ConsoleApp002;
using ConsoleApp002.Entities;

var Bdatos = DataInicial.Cargar();
List<Almacen> almacenes = Bdatos.Item1;
List<Producto> productos = Bdatos.Item2;

bool continuar = true;
while (continuar == true)
{
    Console.WriteLine("MENU PRINCIPAL");
    Console.WriteLine(" MENU DE PRODUCTOS:");
    Console.WriteLine("     1. Lista de Productos");
    Console.WriteLine("     2. Nuevo Producto");
    Console.WriteLine("     3. Modificar Producto");
    Console.WriteLine("     4. Consultar Producto");
    Console.WriteLine("MENU DE ALMACENES:");
    Console.WriteLine("     5. Lista de Almacenes");
    Console.WriteLine("     6. Asignar Producto a Almacen");
    Console.WriteLine("MENU DE VENTA:");
    Console.WriteLine("     7. Generar Pedido de Venta");
    Console.Write("Seleccionar Opcion: ");
    int opcion = int.Parse(Console.ReadLine()!);
    Console.WriteLine("------------------------------------------------");

    switch (opcion)
    {
        #region MENU: PRODUCTOS
        // Lista de Productos
        case 1:
            Console.WriteLine("Lista de Productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToString());
            }

            Console.WriteLine("------------------------------------------------");
            break;
        // Nuevo Producto
        case 2:
            Console.WriteLine("Nuevo Producto:");
            Console.Write("Ingrese Categoria: ");
            string categoria = Console.ReadLine()!;
            Console.Write("Ingrese SubCategoria: ");
            string subcategoria = Console.ReadLine()!;
            Console.Write("Ingrese Edad Recomendada: ");
            int edadRecomendada = int.Parse(Console.ReadLine()!);
            Console.Write("Ingrese Descripcion: ");
            string descripcion = Console.ReadLine()!;
            Console.Write("Ingrese Unidad de Venta: ");
            string unidadVenta = Console.ReadLine()!;
            Console.Write("Ingrese Stock: ");
            int stock = int.Parse(Console.ReadLine()!);
            Console.Write("Ingrese Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine()!);
            Console.Write("Ingrese Almacen ID: ");
            int almacenId = int.Parse(Console.ReadLine()!);
            Producto nuevoProducto = new Producto(productos.Count + 1, categoria, subcategoria, edadRecomendada, descripcion, unidadVenta, stock, precio, almacenId);
            productos.Add(nuevoProducto);
            Console.WriteLine("Producto agregado exitosamente.");
            Console.WriteLine("------------------------------------------------");
            break;
        //  Modificar Producto
        case 3:
            Console.WriteLine("Modificar Producto:");
            Console.Write("Ingrese ID del Producto a Modificar: ");
            int idProductoModificar = int.Parse(Console.ReadLine()!);
            Producto? productoAModificar = productos.FirstOrDefault(p => p.Id == idProductoModificar);
            if (productoAModificar != null)
            {
                Console.Write("Ingrese Nueva Categoria: ");
                productoAModificar.Categoria = Console.ReadLine()!;
                Console.Write("Ingrese Nueva SubCategoria: ");
                productoAModificar.SubCategoria = Console.ReadLine()!;
                Console.Write("Ingrese Nueva Edad Recomendada: ");
                productoAModificar.EdadRecomendada = int.Parse(Console.ReadLine()!);
                Console.Write("Ingrese Nueva Descripcion: ");
                productoAModificar.Descripcion = Console.ReadLine()!;
                Console.Write("Ingrese Nueva Unidad de Venta: ");
                productoAModificar.UnidadVenta = Console.ReadLine()!;
                Console.Write("Ingrese Nuevo Stock: ");
                productoAModificar.Stock = int.Parse(Console.ReadLine()!);
                Console.Write("Ingrese Nuevo Precio: ");
                productoAModificar.Precio = decimal.Parse(Console.ReadLine()!);
                Console.WriteLine("Producto modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.WriteLine("------------------------------------------------");
            break;
        // Consultar Producto
        case 4:
            Console.WriteLine("Consultar Producto:");
            Console.Write("Ingrese ID del Producto a Consultar: ");
            int idProductoConsultar = int.Parse(Console.ReadLine()!);
            Producto? productoAConsultar = productos.FirstOrDefault(p => p.Id == idProductoConsultar);
            if (productoAConsultar != null)
            {
                Console.WriteLine(productoAConsultar.ToString());
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.WriteLine("------------------------------------------------");
            break;
        #endregion

        #region MENU: ALMACENES
        // Lista de Almacenes
        case 5:
            Console.WriteLine("Lista de Almacenes:");
            foreach (var almacen in almacenes)
            {
                Console.WriteLine($"ID: {almacen.Id}, Detalle: {almacen.Detalle}");
            }
            Console.WriteLine("------------------------------------------------");
            break;
        // Asignar Producto a Almacen
        case 6:
            Console.WriteLine("Asignar Producto a Almacen:");
            Console.Write("Ingrese ID del Almacen: ");
            int idAlmacen = int.Parse(Console.ReadLine()!);
            Almacen? almacenSeleccionado = almacenes.FirstOrDefault(a => a.Id == idAlmacen);
            if (almacenSeleccionado != null)
            {
                Console.Write("Ingrese ID del Producto a Asignar: ");
                int idProductoAsignar = int.Parse(Console.ReadLine()!);
                Producto? productoAAsignar = productos.FirstOrDefault(p => p.Id == idProductoAsignar);
                if (productoAAsignar != null)
                {
                    almacenSeleccionado.AgregarProducto(productoAAsignar);
                    Console.WriteLine("Producto asignado al almacen exitosamente.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Almacen no encontrado.");
            }
            Console.WriteLine("------------------------------------------------");
            break;
        #endregion

        #region MENU: VENTA
        case 7:
            Console.WriteLine("Generar Pedido de Venta:");
            Console.Write("Ingrese ID del Producto a Vender: ");
            int idProductoVenta = int.Parse(Console.ReadLine()!);
            Producto? productoAVender = productos.FirstOrDefault(p => p.Id == idProductoVenta);
            if (productoAVender != null)
            {
                Console.Write("Ingrese Cantidad a Vender: ");
                int cantidadVenta = int.Parse(Console.ReadLine()!);
                if (cantidadVenta <= productoAVender.Stock)
                {
                    //  Mostrar total de venta
                    Console.WriteLine("Total de venta: " + (productoAVender.Precio * cantidadVenta).ToString("C"));
                    //  Consultar metodo de pago
                    Console.WriteLine("Métodos de pago:");
                    Console.WriteLine("1. Efectivo");
                    Console.WriteLine("2. Yape");
                    Console.WriteLine("3. Tarjeta de Crédito");
                    Console.WriteLine("4. Tarjeta de Débito");
                    Console.WriteLine("5. Transferencia Bancaria");
                    Console.Write("Seleccione el método de pago: ");
                    int metodoPagoSeleccionado = int.Parse(Console.ReadLine()!);
                    MetodoPago metodoPago = (MetodoPago)(metodoPagoSeleccionado - 1);
                    //  Crear Pedido de Venta
                    Console.WriteLine("Pedido de Venta generado:");
                    PedidoVenta nuevoPedido = new PedidoVenta
                    {
                        ProductoId = productoAVender.Id,
                        Cantidad = cantidadVenta,
                        MetodoPago = metodoPago,
                        Total = productoAVender.Precio * cantidadVenta
                    };
                    Console.WriteLine(nuevoPedido.ToString());

                    // Actualizar el stock del producto
                    productoAVender.Stock -= cantidadVenta;
                    Console.WriteLine($"Venta realizada exitosamente. Stock restante: {productoAVender.Stock}");
                }
                else
                {
                    Console.WriteLine("Stock insuficiente para realizar la venta.");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.WriteLine("------------------------------------------------");
            break;

        #endregion

        default:
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
            Console.WriteLine("------------------------------------------------");
            break;
    }
}






