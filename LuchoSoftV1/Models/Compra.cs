using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class Compra
    {
        public Compra()
        {
            ComprasInsumos = new HashSet<ComprasInsumo>();
        }

        public int IdCompra { get; set; }
        public string NombreCompra { get; set; } = null!;
        public DateTime FechaCompra { get; set; }
        public int EstadoCompra { get; set; }
        public double TotalCompra { get; set; }
        public int IdProveedor { get; set; }

        public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<ComprasInsumo> ComprasInsumos { get; set; }
    }
}
