using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class Producto
    {
        public Producto()
        {
            PedidosProductos = new HashSet<PedidosProducto>();
        }

        public int IdProducto { get; set; }
        public byte[]? ImagenProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string DescripcionProducto { get; set; } = null!;
        public byte EstadoProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int IdCategoriaProducto { get; set; }

        public virtual CategoriaProducto IdCategoriaProductoNavigation { get; set; } = null!;
        public virtual ICollection<PedidosProducto> PedidosProductos { get; set; }
    }
}
