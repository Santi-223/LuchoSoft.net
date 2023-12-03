using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class ComprasInsumo
    {
        public int IdComprasInsumos { get; set; }
        public int CantidadInsumoComprasInsumos { get; set; }
        public double PrecioInsumoComprasInsumos { get; set; }
        public int IdCompra { get; set; }
        public int IdInsumo { get; set; }

        public virtual Compra IdCompraNavigation { get; set; } = null!;
        public virtual Insumo IdInsumoNavigation { get; set; } = null!;
    }
}
