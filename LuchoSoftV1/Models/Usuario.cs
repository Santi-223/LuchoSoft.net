using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public byte EstadoUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; } = null!;
    }
}
