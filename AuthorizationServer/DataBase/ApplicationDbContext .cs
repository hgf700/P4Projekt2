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
    public DbSet<UserLoginData> UserLoginData { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

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
            entity.HasIndex(e => e.Email).IsUnique(); // Upewnij się, że Email jest unikalny
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Scope).HasMaxLength(100);
            entity.Property(e => e.ClientId).IsRequired().HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.RedirectUri).HasMaxLength(200);
            entity.Property(e => e.CodeChallenge).HasMaxLength(200);
            entity.Property(e => e.CodeChallengeMethod).HasMaxLength(50);

            // Relacja jeden do wielu z Key
            entity.HasMany(e => e.Keys)
                  .WithOne(k => k.UserRegisterData)
                  .HasForeignKey(k => k.UserRegisterEmail) // Klucz obcy na podstawie Email
                  .HasPrincipalKey(u => u.Email); // Użycie Email jako klucza głównego

            // Relacja jeden do wielu z UserLoginData
            entity.HasMany(e => e.Userlogindata)
                  .WithOne(l => l.UserRegisterData)
                  .HasForeignKey(l => l.UserRegisterEmail) // Klucz obcy na podstawie Email
                  .HasPrincipalKey(u => u.Email); // Użycie Email jako klucza głównego

            // Relacja jeden do wielu z RefreshToken
            entity.HasMany(e => e.RefreshTokens)
                  .WithOne(r => r.User)
                  .HasForeignKey(r => r.UserEmail) // Klucz obcy na podstawie Email
                  .HasPrincipalKey(u => u.Email); // Użycie Email jako klucza głównego
        });

        // Konfiguracja dla Key
        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.GuidId).IsRequired();
            entity.Property(e => e.AuthorizationKey).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Expire).IsRequired();

            // Klucz obcy do UserRegisterData na podstawie Email
            entity.HasOne(k => k.UserRegisterData)
                  .WithMany(u => u.Keys)
                  .HasForeignKey(k => k.UserRegisterEmail) // Klucz obcy na podstawie Email
                  .HasPrincipalKey(u => u.Email); // Użycie Email jako klucza głównego
        });

        // Konfiguracja dla UserLoginData
        modelBuilder.Entity<UserLoginData>(entity =>
        {
            entity.HasKey(e => e.IdLogin);

            entity.Property(e => e.ResponseType).HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(500);
            entity.Property(e => e.ClientId).IsRequired().HasMaxLength(100);

            // Klucz obcy do UserRegisterData na podstawie Email
            entity.HasOne(l => l.UserRegisterData)
                  .WithMany(u => u.Userlogindata)
                  .HasForeignKey(l => l.UserRegisterEmail) // Klucz obcy na podstawie Email
                  .HasPrincipalKey(u => u.Email); // Użycie Email jako klucza głównego
        });

        // Konfiguracja dla RefreshToken
        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Token).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Expiration).IsRequired();
            entity.Property(e => e.IsRevoked).IsRequired();

            // Konfiguracja relacji na podstawie UserEmail (string) zamiast IdRegister (int)
            entity.HasOne(r => r.User)
                  .WithMany(u => u.RefreshTokens)
                  .HasForeignKey(r => r.UserEmail) // Klucz obcy na podstawie Email
                  .HasPrincipalKey(u => u.Email); // Użycie Email jako klucza głównego
        });
    }
}
