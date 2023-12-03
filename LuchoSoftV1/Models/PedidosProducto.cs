using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class PedidosProducto
    {
        public int IdPedidosProductos { get; set; }
        public DateTime FechaPedidoProducto { get; set; }
        public double CantidadProducto { get; set; }
        public double Subtotal { get; set; }
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
