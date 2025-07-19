using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp002.Entities
{
    public class PedidoVenta : BaseEntity
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public Decimal Total { get; set; }


        public override string ToString()
        {
            return $"PedidoVenta: Id={Id}, ProductoId={ProductoId}, Cantidad={Cantidad}, MetodoPago={MetodoPago}, Total={Total}, FechaCreacion={FechaCreacion}, isActive={isActive}";
        }

    }


    public enum MetodoPago
    {
        Efectivo,
        Yape,
        TarjetaCredito,
        TarjetaDebito,
        TransferenciaBancaria
    }
}
