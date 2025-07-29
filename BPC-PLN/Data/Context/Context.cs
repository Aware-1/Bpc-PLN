using Domain.Entities.Item;
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

    public DbSet<LoginBranchUser> LoginBranchUsers { get; set; }

    public DbSet<LoginProvider> LoginProviderUsers { get; set; }
    public DbSet<ProductItemVM> Products { get; set; }
    public DbSet<RequestOrderHeader> requestOrderHeaders { get; set; }
    public DbSet<RequestOrderLine> requestOrderLines { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductItemVM>().HasNoKey();
        modelBuilder.Entity<LoginBranchUser>().HasNoKey();

        base.OnModelCreating(modelBuilder);

    }
}
