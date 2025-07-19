using ConsoleApp003;

#region GENERAR DATA INICIAL
DataInicial dataInicial = new DataInicial();
List<Producto> MisProductos = dataInicial.Generar(30);
ListaCompras listaCompras = new ListaCompras(0.10m, 100, 0.20m, 400);
#endregion

#region Mostrar Lista de Productos
Console.WriteLine("LISTA DE PRODUCTOS: ");
for (int i = 0; i < MisProductos.Count; i++)
{
    Console.WriteLine("- ID: " + MisProductos[i].Id.ToString().PadRight(3) + " " + MisProductos[i].Descripcion.PadRight(35) + ": " + MisProductos[i].PrecioUnitario.ToString("C"));
}
#endregion

#region Generar Venta de Productos
Console.WriteLine("\nLISTA DE COMPRAS: ");

bool finalizar = false;
int contador = 0;

while (finalizar == false)
{
    //  SELECCIONAR ID Y CANTIDAD DEL PRODUCTO
    Console.Write($"Ingresar el ID del Producto N°{contador + 1}: ");
    int idProducto = Convert.ToInt32(Console.ReadLine());

    //  INFORMACION DEL PRODUCTO
    Producto producto = MisProductos.FirstOrDefault(x => x.Id == idProducto)!;
    Console.Write("     Producto Seleccionado: ");
    Console.WriteLine(producto.Descripcion);

    //  CANTIDAD DEL PRODUCTO
    Console.Write("Ingresar la cantidad del Producto " + producto.Descripcion + ": ");
    int cantidad = Convert.ToInt32(Console.ReadLine());

    listaCompras.AgregarRegistro(producto, cantidad);
    Console.Write("     Total Parcial: ");
    Console.WriteLine(listaCompras.TotalesParciales[contador].ToString("C"));

    //  CONSULTAR SI DESEA AGREGAR MAS PRODUCTOS
    Console.Write("Desea agregar más productos (S/N)? ");
    string confirmacion = Console.ReadLine()!;
    Console.WriteLine("\n");
    if (confirmacion!.ToUpper() == "S")
    {
        finalizar = false;
    }
    else
    {
        finalizar = true;
        listaCompras.CalcularTotal();
    }
    contador++;
}




#endregion