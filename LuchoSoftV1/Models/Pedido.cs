using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidosProductos = new HashSet<PedidosProducto>();
        }

        public int IdPedido { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaPedido { get; set; }
        public int EstadoPedido { get; set; }
        public double TotalVenta { get; set; }
        public double TotalPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<PedidosProducto> PedidosProductos { get; set; }
    }
}
