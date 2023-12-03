using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class OrdenesDeProduccion
    {
        public OrdenesDeProduccion()
        {
            OrdenInsumos = new HashSet<OrdenInsumo>();
        }

        public int IdOrdenDeProduccion { get; set; }
        public string DescripcionOrden { get; set; } = null!;
        public DateTime FechaOrden { get; set; }
        public int IdEmpleado { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<OrdenInsumo> OrdenInsumos { get; set; }
    }
}
