using CDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CDB.Persistence.Context;

public class CdbContext : DbContext
{
    public CdbContext(DbContextOptions<CdbContext> options) : base(options) { }

    public DbSet<MesesImposto> MesesImposto { get; set; }
    public DbSet<TbCdi> TbCdi { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MesesImposto>(entity =>
        {
            entity.HasKey(m => m.MesesImpostoId);
            entity.Property(m => m.QtdMeses).IsRequired();
            entity.Property(m => m.PorcentagemImposto).IsRequired();
        });

        modelBuilder.Entity<TbCdi>(entity =>
        {
            entity.HasKey(t => t.TbCdiId);
            entity.Property(t => t.Tb).IsRequired();
            entity.Property(t => t.Cdi).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }  
}
