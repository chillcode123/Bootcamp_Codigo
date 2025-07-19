using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp003
{
    public class ListaCompras
    {
        public List<Producto> Productos = new List<Producto>();
        public List<int> Cantidades = new List<int>();
        public List<decimal> TotalesParciales = new List<decimal>();
        public decimal TotalFinal = 0;

        private decimal descuento1 = 0;
        private decimal montoMin1 = 0;
        private decimal descuento2 = 0;
        private decimal montoMin2 = 0;

        public ListaCompras(decimal desc1, decimal monto1, decimal desc2, decimal monto2 )
        {
            descuento1 = desc1;
            descuento2 = desc2;
            montoMin1 = monto1;
            montoMin2 = monto2;            
        }

        #region METODOS
        public void AgregarRegistro(Producto producto, int cantidad)
        {
            Productos.Add(producto);
            Cantidades.Add(cantidad);
            TotalesParciales.Add(producto.PrecioUnitario * cantidad);
        }

        public void CalcularTotal()
        {
            for (int i = 0; i < TotalesParciales.Count; i++)
            {
                TotalFinal += TotalesParciales[i];
            }

            //  DESCUENTO 2: 15% - COMPRA MIN 400
            if (TotalFinal > montoMin2)
            {
                Console.WriteLine("TOTAL SIN DESCUENTO: " + TotalFinal.ToString("C"));
                TotalFinal = TotalFinal * (1 - descuento2);
                Console.WriteLine($"     Felicidades: Aplicaste para un {descuento2 * 100}% de descuento");
                Console.WriteLine("TOTAL CON DESCUENTO: " + TotalFinal.ToString("C"));
            }
            //  DESCUENTO 1: 10% - COMPRA MIN 100
            else if (TotalFinal > montoMin1)
            {
                Console.WriteLine("TOTAL SIN DESCUENTO: " + TotalFinal.ToString("C"));
                TotalFinal = TotalFinal * (1 - descuento1);
                Console.WriteLine($"     Felicidades: Aplicaste para un {descuento1 * 100}% de descuento");
                Console.WriteLine("TOTAL CON DESCUENTO: " + TotalFinal.ToString("C"));
            }
            else
            {
                Console.WriteLine("TOTAL DE LA COMPRA: " + TotalFinal.ToString("C"));
            }  
        }
        #endregion

    }
}
