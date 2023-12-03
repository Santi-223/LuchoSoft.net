using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LuchoSoftV1.Models
{
    public partial class LuchoSoftContext : DbContext
    {
        public LuchoSoftContext()
        {
        }

        public LuchoSoftContext(DbContextOptions<LuchoSoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaInsumo> CategoriaInsumos { get; set; } = null!;
        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<ComprasInsumo> ComprasInsumos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Insumo> Insumos { get; set; } = null!;
        public virtual DbSet<OrdenInsumo> OrdenInsumos { get; set; } = null!;
        public virtual DbSet<OrdenesDeProduccion> OrdenesDeProduccions { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<PedidosProducto> PedidosProductos { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolesPermiso> RolesPermisos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MEDAPRCSGFSP056;Initial Catalog=LuchoSoft;Integrated Security=True");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaInsumo>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaInsumos)
                    .HasName("PK__categori__35153FEBD46372A6");

                entity.ToTable("categoria_insumos");

                entity.Property(e => e.IdCategoriaInsumos).HasColumnName("id_categoria_insumos");

                entity.Property(e => e.EstadoCategoriaInsumos)
                    .HasColumnName("estado_categoria_insumos")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCategoriaInsumos)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_categoria_insumos");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaProductos)
                    .HasName("PK__categori__B76398B24C1DB40A");

                entity.ToTable("categoria_productos");

                entity.Property(e => e.IdCategoriaProductos).HasColumnName("id_categoria_productos");

                entity.Property(e => e.EstadoCategoriaProductos)
                    .HasColumnName("estado_categoria_productos")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCategoriaProductos)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_categoria_productos");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__clientes__677F38F523FAA10F");

                entity.ToTable("clientes");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("id_cliente");

                entity.Property(e => e.ClienteFrecuente).HasColumnName("cliente_frecuente");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("direccion_cliente");

                entity.Property(e => e.EstadoCliente)
                    .HasColumnName("estado_cliente")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefono_cliente");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__compras__C4BAA604BE4EC66C");

                entity.ToTable("compras");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.EstadoCompra).HasColumnName("estado_compra");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fecha_compra");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.Property(e => e.NombreCompra)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_compra");

                entity.Property(e => e.TotalCompra).HasColumnName("total_compra");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_proveedor_compra");
            });

            modelBuilder.Entity<ComprasInsumo>(entity =>
            {
                entity.HasKey(e => e.IdComprasInsumos)
                    .HasName("PK__compras___5C02063E399CBE21");

                entity.ToTable("compras_insumos");

                entity.Property(e => e.IdComprasInsumos).HasColumnName("id_compras_insumos");

                entity.Property(e => e.CantidadInsumoComprasInsumos).HasColumnName("cantidad_insumo_compras_insumos");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.IdInsumo).HasColumnName("id_insumo");

                entity.Property(e => e.PrecioInsumoComprasInsumos).HasColumnName("precio_insumo_compras_insumos");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.ComprasInsumos)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_compras_detalle");

                entity.HasOne(d => d.IdInsumoNavigation)
                    .WithMany(p => p.ComprasInsumos)
                    .HasForeignKey(d => d.IdInsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_insumo_detalle");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__empleado__88B513940B5F2844");

                entity.ToTable("empleados");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.DireccionEmpleado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("direccion_empleado");

                entity.Property(e => e.EstadoEmpleado).HasColumnName("estado_empleado");

                entity.Property(e => e.ImagenEmpleado).HasColumnName("imagen_empleado");

                entity.Property(e => e.NombreEmpleado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_empleado");

                entity.Property(e => e.TelefonoEmpleado)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefono_empleado");
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.HasKey(e => e.IdInsumo)
                    .HasName("PK__insumos__D4F202B1ACFA9CF0");

                entity.ToTable("insumos");

                entity.Property(e => e.IdInsumo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_insumo");

                entity.Property(e => e.EstadoInsumo)
                    .HasColumnName("estado_insumo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdCategoriaInsumo).HasColumnName("id_categoria_insumo");

                entity.Property(e => e.ImagenInsumo).HasColumnName("imagen_insumo");

                entity.Property(e => e.NombreInsumo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_insumo");

                entity.Property(e => e.StockInsumo).HasColumnName("stock_insumo");

                entity.Property(e => e.UnidadesDeMedidaInsumo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("unidadesDeMedida_insumo");

                entity.HasOne(d => d.IdCategoriaInsumoNavigation)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.IdCategoriaInsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_categoria_insumo");
            });

            modelBuilder.Entity<OrdenInsumo>(entity =>
            {
                entity.HasKey(e => e.IdOrdenInsumos)
                    .HasName("PK__orden_in__9E06C0D2A2A478F0");

                entity.ToTable("orden_insumos");

                entity.Property(e => e.IdOrdenInsumos).HasColumnName("id_orden_insumos");

                entity.Property(e => e.CantidadInsumoOrdenInsumos).HasColumnName("cantidad_insumo_orden_insumos");

                entity.Property(e => e.DescripcionOrdenInsumos)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_orden_insumos");

                entity.Property(e => e.IdInsumo).HasColumnName("id_insumo");

                entity.Property(e => e.IdOrdenDeProduccion).HasColumnName("id_orden_de_produccion");

                entity.HasOne(d => d.IdInsumoNavigation)
                    .WithMany(p => p.OrdenInsumos)
                    .HasForeignKey(d => d.IdInsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_insumos_detalle_orden");

                entity.HasOne(d => d.IdOrdenDeProduccionNavigation)
                    .WithMany(p => p.OrdenInsumos)
                    .HasForeignKey(d => d.IdOrdenDeProduccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_orden_detalle_orden");
            });

            modelBuilder.Entity<OrdenesDeProduccion>(entity =>
            {
                entity.HasKey(e => e.IdOrdenDeProduccion)
                    .HasName("PK__ordenes___AAC0EDB1C5242B0A");

                entity.ToTable("ordenes_de_produccion");

                entity.Property(e => e.IdOrdenDeProduccion).HasColumnName("id_orden_de_produccion");

                entity.Property(e => e.DescripcionOrden)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_orden");

                entity.Property(e => e.FechaOrden)
                    .HasColumnType("date")
                    .HasColumnName("fecha_orden");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.OrdenesDeProduccions)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_usuario_orden");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__pedidos__6FF014892FAB7352");

                entity.ToTable("pedidos");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.EstadoPedido).HasColumnName("estado_pedido");

                entity.Property(e => e.FechaPedido)
                    .HasColumnType("date")
                    .HasColumnName("fecha_pedido");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fecha_venta");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.TotalPedido).HasColumnName("total_pedido");

                entity.Property(e => e.TotalVenta).HasColumnName("total_venta");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_cliente_pedido");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_usuario_pedido");
            });

            modelBuilder.Entity<PedidosProducto>(entity =>
            {
                entity.HasKey(e => e.IdPedidosProductos)
                    .HasName("PK__pedidos___0E25F448713C6BCC");

                entity.ToTable("pedidos_productos");

                entity.Property(e => e.IdPedidosProductos).HasColumnName("id_pedidos_productos");

                entity.Property(e => e.CantidadProducto).HasColumnName("cantidad_producto");

                entity.Property(e => e.FechaPedidoProducto)
                    .HasColumnType("date")
                    .HasColumnName("fecha_pedido_producto");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidosProductos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_pedido_detalle");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.PedidosProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_producto_detalle");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__permisos__228F224F7874B850");

                entity.ToTable("permisos");

                entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");

                entity.Property(e => e.EstadoPermiso)
                    .HasColumnName("estado_permiso")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombrePermiso)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_permiso");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__FF341C0D1DB5142B");

                entity.ToTable("productos");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_producto");

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_producto");

                entity.Property(e => e.EstadoProducto)
                    .HasColumnName("estado_producto")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdCategoriaProducto).HasColumnName("id_categoria_producto");

                entity.Property(e => e.ImagenProducto).HasColumnName("imagen_producto");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto");

                entity.Property(e => e.PrecioProducto).HasColumnName("precio_producto");

                entity.HasOne(d => d.IdCategoriaProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoriaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_categoria_producto");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__proveedo__8D3DFE283BB97CB1");

                entity.ToTable("proveedores");

                entity.Property(e => e.IdProveedor)
                    .ValueGeneratedNever()
                    .HasColumnName("id_proveedor");

                entity.Property(e => e.DireccionProveedor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("direccion_proveedor");

                entity.Property(e => e.EstadoProveedor)
                    .HasColumnName("estado_proveedor")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreProveedor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_proveedor");

                entity.Property(e => e.TelefonoProveedor)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefono_proveedor");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__roles__6ABCB5E096D9DF32");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.DescripcionRol)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_rol");

                entity.Property(e => e.EstadoRol)
                    .HasColumnName("estado_rol")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_rol");
            });

            modelBuilder.Entity<RolesPermiso>(entity =>
            {
                entity.HasKey(e => e.IdRolesPermisos)
                    .HasName("PK__roles_pe__AE1DEBCB99EEC22D");

                entity.ToTable("roles_permisos");

                entity.Property(e => e.IdRolesPermisos).HasColumnName("id_roles_permisos");

                entity.Property(e => e.FechaRolesPermisos)
                    .HasColumnType("date")
                    .HasColumnName("fecha_roles_permisos");

                entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.RolesPermisos)
                    .HasForeignKey(d => d.IdPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_permiso_detalle_roles_permisos");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolesPermisos)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_rol_detalle_roles_permisos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__4E3E04AD132FA94B");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("id_usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EstadoUsuario)
                    .HasColumnName("estado_usuario")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_rol_login");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
