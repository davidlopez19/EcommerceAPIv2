using EcommerceAPI.Infraestructura.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.Database.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        #region DBSets
        public virtual DbSet<ClienteEntity> Clientes { get; set; }

        #endregion
    }
}
