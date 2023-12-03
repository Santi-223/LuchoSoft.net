using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class RolesPermiso
    {
        public int IdRolesPermisos { get; set; }
        public DateTime FechaRolesPermisos { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }

        public virtual Permiso IdPermisoNavigation { get; set; } = null!;
        public virtual Role IdRolNavigation { get; set; } = null!;
    }
}
