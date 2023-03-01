using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZodiacSignLibrary.Models.Entities;

namespace ZodiacSignLibrary.Models
{
    public class ZodiacSignDbContext : DbContext
    {
        private static ZodiacSignDbContext _context = new();

        public ZodiacSignDbContext()
        {
        }

        public static void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<ZodiacSignDbContext>();

        public ZodiacSignDbContext(DbContextOptions<ZodiacSignDbContext> options)
            : base(options)
        {
        }

        public static ZodiacSignDbContext GetContext() => _context ??= new();


        public virtual DbSet<Admin> Admin { get; set; } = null!;
        public virtual DbSet<Client> Client { get; set; } = null!;
        public virtual DbSet<Services> Services { get; set; } = null!;
        public virtual DbSet<ZodiacSignInfo> ZodiacSignInfo { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Admin>().Property(a => a.Id).UseIdentityColumn();
            modelBuilder.Entity<Client>().Property(c => c.Id).UseIdentityColumn();
            modelBuilder.Entity<Services>().Property(s => s.Id).UseIdentityColumn();
            modelBuilder.Entity<ZodiacSignInfo>().Property(z => z.Id).UseIdentityColumn();

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseNpgsql("Host=localhost;Port=5432;Database=ZodiacSignDatabase;Username=postgres;Password=1234");
            
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
