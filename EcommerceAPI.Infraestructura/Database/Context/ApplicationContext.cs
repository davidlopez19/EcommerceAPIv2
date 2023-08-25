using EcommerceAPI.Infraestructura.Database.Entities.Clientes;
using EcommerceAPI.Infraestructura.Database.Entities.Compras;
using EcommerceAPI.Infraestructura.Database.Entities.Productos;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace EcommerceAPI.Infraestructura.Database.Context
{
    public class ApplicationContext : DbContext
    {
        #region [DBSets]
        public virtual DbSet<ClientesEntities> Clientes { get; set; }
        public virtual DbSet<ProductosEntities> Productos { get; set; }
        public virtual DbSet<StockEntities> Stocks { get; set; }
        public virtual DbSet<ComprasEntities> Compras { get; set; }
        public virtual DbSet<DetalleComprasEntities> DetalleCompras { get; set; }
        #endregion
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
