using System;
using System.Collections.Generic;
using AcopioExpress.Model;
using Microsoft.EntityFrameworkCore;

namespace AcopioExpress.DAL.DBContext;

public partial class AcopioExpressDbContext : DbContext
{
    public AcopioExpressDbContext()
    {
    }

    public AcopioExpressDbContext(DbContextOptions<AcopioExpressDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acopio> Acopios { get; set; }

    public virtual DbSet<Bodega> Bodegas { get; set; }

    public virtual DbSet<DetalleVentaInsumo> DetalleVentaInsumos { get; set; }

    public virtual DbSet<EgresosAcopio> EgresosAcopios { get; set; }

    public virtual DbSet<IngresosAcopio> IngresosAcopios { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<LiquidacionProductor> LiquidacionProductors { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Produccion> Produccions { get; set; }

    public virtual DbSet<RolUser> RolUsers { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<VentaInsumo> VentaInsumos { get; set; }

    public virtual DbSet<VentaProduccion> VentaProduccions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acopio>(entity =>
        {
            entity.HasKey(e => e.IdAcopio).HasName("PK__Acopio__8E7349014DF6FCFA");

            entity.ToTable("Acopio");

            entity.Property(e => e.IdAcopio).HasColumnName("idAcopio");
            entity.Property(e => e.CantidadEmpleados).HasColumnName("cantidadEmpleados");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.NombreAcopi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreAcopi");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Bodega>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Bodega");

            entity.Property(e => e.CantidadAlmacenada).HasColumnName("cantidadAlmacenada");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.IdBodega)
                .ValueGeneratedOnAdd()
                .HasColumnName("idBodega");
        });

        modelBuilder.Entity<DetalleVentaInsumo>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVentaInsumo).HasName("PK__DetalleV__7059CCE71D1FE753");

            entity.ToTable("DetalleVentaInsumo");

            entity.Property(e => e.IdDetalleVentaInsumo).HasColumnName("idDetalleVentaInsumo");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.IdInsumo).HasColumnName("id_Insumo");
            entity.Property(e => e.IdVentaInsumo).HasColumnName("id_VentaInsumo");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.TotalVentaInsumo).HasColumnName("totalVentaInsumo");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleVentaInsumos)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__id_In__09A971A2");

            entity.HasOne(d => d.IdVentaInsumoNavigation).WithMany(p => p.DetalleVentaInsumos)
                .HasForeignKey(d => d.IdVentaInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__id_Ve__0A9D95DB");
        });

        modelBuilder.Entity<EgresosAcopio>(entity =>
        {
            entity.HasKey(e => e.IdEgresosAcopio).HasName("PK__EgresosA__75C625F22CBA0A15");

            entity.ToTable("EgresosAcopio");

            entity.Property(e => e.IdEgresosAcopio).HasColumnName("idEgresosAcopio");
            entity.Property(e => e.Arriendo).HasColumnName("arriendo");
            entity.Property(e => e.FechaFinalIngresosEgresos)
                .HasColumnType("date")
                .HasColumnName("fechaFinalIngresosEgresos");
            entity.Property(e => e.FechaInicailEgresos)
                .HasColumnType("date")
                .HasColumnName("fechaInicailEgresos");
            entity.Property(e => e.GastosExtras).HasColumnName("gastosExtras");
            entity.Property(e => e.IdAcopio).HasColumnName("id_acopio");
            entity.Property(e => e.Servicios).HasColumnName("servicios");
            entity.Property(e => e.SumatoriaLiquidacion).HasColumnName("sumatoriaLiquidacion");
            entity.Property(e => e.SumatoriaNominas).HasColumnName("sumatoriaNominas");

            entity.HasOne(d => d.IdAcopioNavigation).WithMany(p => p.EgresosAcopios)
                .HasForeignKey(d => d.IdAcopio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EgresosAc__id_ac__6E01572D");
        });

        modelBuilder.Entity<IngresosAcopio>(entity =>
        {
            entity.HasKey(e => e.IdIngresosAcopio).HasName("PK__Ingresos__1287CDC29DB2C72B");

            entity.ToTable("IngresosAcopio");

            entity.Property(e => e.IdIngresosAcopio).HasColumnName("idIngresosAcopio");
            entity.Property(e => e.FechaFinalIngresosLiquidacion)
                .HasColumnType("date")
                .HasColumnName("fechaFinalIngresosLiquidacion");
            entity.Property(e => e.FechaInicailIngresos)
                .HasColumnType("date")
                .HasColumnName("fechaInicailIngresos");
            entity.Property(e => e.IdAcopio).HasColumnName("id_acopio");
            entity.Property(e => e.TotalGananciaInsumos).HasColumnName("totalGananciaInsumos");

            entity.HasOne(d => d.IdAcopioNavigation).WithMany(p => p.IngresosAcopios)
                .HasForeignKey(d => d.IdAcopio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IngresosA__id_ac__70DDC3D8");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__Insumo__215CA054C5E4AB8E");

            entity.ToTable("Insumo");

            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.GananciaUnitaria).HasColumnName("gananciaUnitaria");
            entity.Property(e => e.NombreInsumo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreInsumo");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.ValorTotalInsumosV)
                .HasComputedColumnSql("([valorUnitarioVenta]*[stock])", false)
                .HasColumnName("valorTotalInsumosV");
            entity.Property(e => e.ValorTotalUcompra)
                .HasComputedColumnSql("([valorUnitarioCompra]*[stock])", false)
                .HasColumnName("valorTotalUCompra");
            entity.Property(e => e.ValorUnitarioCompra).HasColumnName("valorUnitarioCompra");
            entity.Property(e => e.ValorUnitarioVenta).HasColumnName("valorUnitarioVenta");
        });

        modelBuilder.Entity<LiquidacionProductor>(entity =>
        {
            entity.HasKey(e => e.IdLiquidacion).HasName("PK__Liquidac__AD38F40FA36DF26F");

            entity.ToTable("LiquidacionProductor");

            entity.Property(e => e.IdLiquidacion).HasColumnName("idLiquidacion");
            entity.Property(e => e.FechaLiquidacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("fechaLiquidacion");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.TotalInsumos).HasColumnName("totalInsumos");
            entity.Property(e => e.TotalPagar).HasComputedColumnSql("([totalProduccion]-[totalInsumos])", false);
            entity.Property(e => e.TotalProduccion).HasColumnName("totalProduccion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.LiquidacionProductors)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Liquidaci__id_pe__6B24EA82");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__Login__068B3EBB46C3AFBE");

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin).HasColumnName("idLogin");
            entity.Property(e => e.IdAcopio).HasColumnName("id_Acopio");
            entity.Property(e => e.IdRol).HasColumnName("id_Rol");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdAcopioNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.IdAcopio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Login__id_Acopio__403A8C7D");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Login__id_Rol__3F466844");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.IdNomina).HasName("PK__Nomina__BB6DB673DA9AD459");

            entity.ToTable("Nomina");

            entity.Property(e => e.IdNomina).HasColumnName("idNomina");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("fechaPago");
            entity.Property(e => e.IdPersona).HasColumnName("id_Persona");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salario");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nomina__id_Perso__6754599E");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__A4788141DA39F555");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cedula)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.IdAcopio).HasColumnName("id_Acopio");
            entity.Property(e => e.IdRol).HasColumnName("id_Rol");
            entity.Property(e => e.IdTipoProducto).HasColumnName("id_TipoProducto");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdAcopioNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdAcopio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona__id_Acop__47DBAE45");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona__id_Rol__46E78A0C");

            entity.HasOne(d => d.IdTipoProductoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona__id_Tipo__48CFD27E");
        });

        modelBuilder.Entity<Produccion>(entity =>
        {
            entity.HasKey(e => e.IdProduccion).HasName("PK__Producci__CB8825D88FE296D6");

            entity.ToTable("Produccion");

            entity.Property(e => e.IdProduccion).HasColumnName("idProduccion");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DiaIngresoProducto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("diaIngresoProducto");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.IdPersona).HasColumnName("id_Persona");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.PrecioProducto).HasColumnName("precioProducto");
            entity.Property(e => e.ValorProducto)
                .HasComputedColumnSql("([cantidad]*[precioProducto])", false)
                .HasColumnName("valorProducto");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Produccions)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produccio__id_Pe__4D94879B");
        });

        modelBuilder.Entity<RolUser>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol_User__3C872F76EDECEE51");

            entity.ToTable("Rol_User");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago).HasName("PK__TipoPago__AC5BA85B302DC3CC");

            entity.ToTable("TipoPago");

            entity.Property(e => e.IdTipoPago).HasColumnName("idTipoPago");
            entity.Property(e => e.NombreTipoProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoProducto");
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.IdTipoProducto).HasName("PK__TipoProd__2552C5A5D18D0420");

            entity.ToTable("TipoProducto");

            entity.Property(e => e.IdTipoProducto).HasColumnName("idTipoProducto");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.TipoProducto1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoProducto");
        });

        modelBuilder.Entity<VentaInsumo>(entity =>
        {
            entity.HasKey(e => e.IdVentaInsumo).HasName("PK__VentaIns__DD5573BCD53A6EC3");

            entity.ToTable("VentaInsumo");

            entity.Property(e => e.IdVentaInsumo).HasColumnName("idVentaInsumo");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdPersona).HasColumnName("id_Persona");
            entity.Property(e => e.IdTipoPago).HasColumnName("id_tipoPago");
            entity.Property(e => e.Observacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.VentaInsumos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaInsu__id_Pe__04E4BC85");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.VentaInsumos)
                .HasForeignKey(d => d.IdTipoPago)
                .HasConstraintName("FK__VentaInsu__id_ti__05D8E0BE");
        });

        modelBuilder.Entity<VentaProduccion>(entity =>
        {
            entity.HasKey(e => e.IdVentaProduccion).HasName("PK__VentaPro__4AEB72ACAE625716");

            entity.ToTable("VentaProduccion");

            entity.Property(e => e.IdVentaProduccion).HasColumnName("idVentaProduccion");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("fechaVenta");
            entity.Property(e => e.IdAcopio).HasColumnName("id_Acopio");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.TotalVentaProduccion)
                .HasComputedColumnSql("([cantidad]*[precio])", false)
                .HasColumnType("decimal(21, 2)")
                .HasColumnName("totalVentaProduccion");

            entity.HasOne(d => d.IdAcopioNavigation).WithMany(p => p.VentaProduccions)
                .HasForeignKey(d => d.IdAcopio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaProd__id_Ac__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
