using CDB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CDB.Persistence.Context;

public class CdbContext : DbContext
{
    public CdbContext(DbContextOptions<CdbContext> options) : base(options) { }

    public DbSet<MesesImposto> MesesImposto { get; set; }
    public DbSet<TbCdi> TbCdi { get; set; }
}