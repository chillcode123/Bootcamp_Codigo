using Bogus;

namespace ConsoleApp003
{
    public class DataInicial
    {
        public List<Producto> Productos { get; set; }

        public DataInicial()
        {
            Productos = new List<Producto>();
        }

        public List<Producto> Generar(int numProductos)
        {
            int id = 1;
            //  Bogus
            var faker = new Faker<Producto>()
                .CustomInstantiator(f =>
                    new Producto(
                        id++,
                        f.Commerce.ProductName(),
                        decimal.Parse(f.Commerce.Price(10, 100))
                    )
                );

            List<Producto> productos = faker.Generate(numProductos);
            return productos;
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Producto(int id, string descripcion, decimal precioUnitario)
        {
            Id = id;
            Descripcion = descripcion;
            PrecioUnitario = precioUnitario;
        }
    }

}
