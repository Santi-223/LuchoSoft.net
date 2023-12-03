﻿using System;
using System.Collections.Generic;

namespace LuchoSoftV1.Models
{
    public partial class Insumo
    {
        public Insumo()
        {
            ComprasInsumos = new HashSet<ComprasInsumo>();
            OrdenInsumos = new HashSet<OrdenInsumo>();
        }

        public int IdInsumo { get; set; }
        public byte[]? ImagenInsumo { get; set; }
        public string NombreInsumo { get; set; } = null!;
        public string UnidadesDeMedidaInsumo { get; set; } = null!;
        public double StockInsumo { get; set; }
        public byte EstadoInsumo { get; set; }
        public int IdCategoriaInsumo { get; set; }

        public virtual CategoriaInsumo IdCategoriaInsumoNavigation { get; set; } = null!;
        public virtual ICollection<ComprasInsumo> ComprasInsumos { get; set; }
        public virtual ICollection<OrdenInsumo> OrdenInsumos { get; set; }
    }
}
