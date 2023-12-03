using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class OrdenInsumo
    {
        public int IdOrdenInsumos { get; set; }
        public string? DescripcionOrdenInsumos { get; set; }
        public double CantidadInsumoOrdenInsumos { get; set; }
        public int IdOrdenDeProduccion { get; set; }
        public int IdInsumo { get; set; }

        public virtual Insumo IdInsumoNavigation { get; set; } = null!;
        public virtual OrdenesDeProduccion IdOrdenDeProduccionNavigation { get; set; } = null!;
    }
}
