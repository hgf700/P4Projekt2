using IdentityService.DataBase;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Definiowanie DbSet dla Twoich encji
    public DbSet<UserSavedData> usersaveddata{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserSavedData>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Granttype).IsRequired();
            entity.Property(e => e.Firstname).IsRequired();
            entity.Property(e => e.Lastname).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.ClientId).IsRequired();
        });
    }
}
