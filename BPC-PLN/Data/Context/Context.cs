using Domain.Dtos;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class UnityDbContext : DbContext
{
    public UnityDbContext(DbContextOptions<UnityDbContext> options) : base(options) { }

    public DbSet<BranchUser> BranchUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BranchUser>().HasNoKey().ToView("BPCView_006_PortalUserInfo");

        base.OnModelCreating(modelBuilder);
    }
}



public class BpcwebserverDbContext : DbContext
{
    public BpcwebserverDbContext(DbContextOptions<BpcwebserverDbContext> options) : base(options) { }

    public DbSet<LoginProvider> ProviderUsers { get; set; }
    public DbSet<ProductItem> Products { get; set; }

}

