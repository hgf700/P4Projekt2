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
    public DbSet<Key> Keys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Konfiguracja dla UserRegisterData
        modelBuilder.Entity<UserRegisterData>(entity =>
        {
            entity.HasKey(e => e.IdRegister);

            entity.Property(e => e.ResponseType).HasMaxLength(100);
            entity.Property(e => e.Firstname).HasMaxLength(100);
            entity.Property(e => e.Lastname).HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Scope).HasMaxLength(100);
            entity.Property(e => e.ClientId).IsRequired().HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.RedirectUri).HasMaxLength(200);
            entity.Property(e => e.CodeChallenge).HasMaxLength(200);
            entity.Property(e => e.CodeChallengeMethod).HasMaxLength(50);

            // Relacja wiele do wielu z Key
            entity.HasMany(e => e.Keys)
                  .WithMany(k => k.Users)
                  .UsingEntity<Dictionary<string, object>>(
                      "UserKey",
                      j => j.HasOne<Key>().WithMany().HasForeignKey("KeyId"),
                      j => j.HasOne<UserRegisterData>().WithMany().HasForeignKey("UserId"));
        });

        // Konfiguracja dla Key
        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.GuidId);
            entity.Property(e => e.AuthorizationKey);
            entity.Property(e => e.Expire);

            // Relacja wiele do wielu z UserRegisterData
            entity.HasMany(k => k.Users)
                  .WithMany(u => u.Keys)
                  .UsingEntity<Dictionary<string, object>>(
                      "UserKey",
                      j => j.HasOne<UserRegisterData>().WithMany().HasForeignKey("UserId"),
                      j => j.HasOne<Key>().WithMany().HasForeignKey("KeyId"));
        });
    }
}
