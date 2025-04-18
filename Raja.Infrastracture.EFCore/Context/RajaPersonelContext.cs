using Microsoft.EntityFrameworkCore;
using Raja.Domain.Entities;
using Raja.Infrastracture.EFCore.FluentConfig;

namespace Raja.Infrastracture.EFCore.Context
{
    public class RajaPersonelContext : DbContext
    {
        
        public DbSet<Personel> Personels { get; set; }
        public DbSet<PersonelDetail> PersonelsDetails { get; set; }
        public RajaPersonelContext(DbContextOptions<RajaPersonelContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonelFluentConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
