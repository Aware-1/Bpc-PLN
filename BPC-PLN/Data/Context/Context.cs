using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Data.Context
{

    public class BpcwebserverDbContext : DbContext
    {
        public BpcwebserverDbContext(DbContextOptions<BpcwebserverDbContext> options) : base(options) { }
      
        public DbSet<LoginBranchDto> BranchUsers { get; set; }
        public DbSet<LoginProviderDto> ProviderUsers { get; set; }
        public DbSet<ProductItem> Products { get; set; }


    }

    public class UnityDbContext : DbContext
    {
        public UnityDbContext(DbContextOptions<UnityDbContext> options) : base(options) { }
        public DbSet<HeaderBranchDto> BranchUsers { get; set; }


    }

}
