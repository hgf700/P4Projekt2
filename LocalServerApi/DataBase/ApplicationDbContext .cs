using IdentityService.DataBase;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Definiowanie DbSet dla Twoich encji
    public DbSet<UserRegisterData> UserRegisterData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure UserRegisterData
        modelBuilder.Entity<UserRegisterData>(entity =>
        {
            entity.HasKey(e => e.IdRegister);
            entity.Property(e => e.ResponseType);
            entity.Property(e => e.Firstname);
            entity.Property(e => e.Lastname);
            entity.Property(e => e.Email);
            entity.Property(e => e.PasswordHash);
            entity.Property(e => e.Scope);
            entity.Property(e => e.ClientId).IsRequired();
        });
    }
}
