using IdentityService.DataBase;
using Microsoft.EntityFrameworkCore;
using P4Projekt2.API.User;

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
    public DbSet<ChatData> ChatData { get; set; }
    public DbSet<AddToFriendList> AddToFriendList { get; set; }

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

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(255);
            entity.HasIndex(e => e.Email);

            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Scope).HasMaxLength(100);
            entity.Property(e => e.ClientId).IsRequired().HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.RedirectUri).HasMaxLength(200);
            entity.Property(e => e.CodeChallenge).HasMaxLength(200);
            entity.Property(e => e.CodeChallengeMethod).HasMaxLength(50);

            entity.HasMany(e => e.Keys)
                .WithOne(k => k.UserRegisterData)
                .HasForeignKey(k => k.UserRegisterEmail)
                .HasPrincipalKey(u => u.Email);

            entity.HasMany(e => e.Userlogindata)
                .WithOne(l => l.Userregisterdata)
                .HasForeignKey(l => l.UserRegisterEmail)
                .HasPrincipalKey(u => u.Email);

            entity.HasMany(e => e.RefreshTokens)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserEmail)
                .HasPrincipalKey(u => u.Email);
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

        modelBuilder.Entity<UserLoginData>(entity =>
        {
            entity.HasKey(e => e.IdLogin);

            entity.Property(e => e.ResponseType).HasMaxLength(100);
            entity.Property(e => e.Email1)
                  .IsRequired()
                  .HasMaxLength(255); // Usunięcie unikalności
            entity.Property(e => e.Email2)
                  .IsRequired()
                  .HasMaxLength(255); // Usunięcie unikalności

            entity.Property(e => e.Password).IsRequired().HasMaxLength(500);
            entity.Property(e => e.ClientId).IsRequired().HasMaxLength(100);

            entity.HasOne(l => l.Userregisterdata)
                  .WithMany(r => r.Userlogindata)
                  .HasForeignKey(l => l.UserRegisterEmail)
                  .HasPrincipalKey(r => r.Email);
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

        // Konfiguracja dla ChatData
        modelBuilder.Entity<ChatData>(entity =>
        {
            entity.HasKey(e => e.MessageId);
            entity.Property(e => e.Message).IsRequired();
            entity.Property(e => e.Timestamp).IsRequired();

            // Relacja do UserLoginData dla Sender, na podstawie Email
            entity.HasOne(e => e.Sender)
                  .WithMany(u => u.SentMessages)
                  .HasForeignKey(e => e.SenderEmail)
                  .HasPrincipalKey(u => u.Email1)
                  .OnDelete(DeleteBehavior.Restrict);

            // Relacja do UserLoginData dla Receiver, na podstawie Email
            entity.HasOne(e => e.Receiver)
                  .WithMany(u => u.ReceivedMessages)
                  .HasForeignKey(e => e.ReceiverEmail)
                  .HasPrincipalKey(u => u.Email2)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AddToFriendList>(entity =>
        {
            entity.HasKey(f => f.Id);

            // Relationship to UserLoginData (Requester)
            entity.HasOne(f => f.Requester)
                  .WithMany(u => u.SentFriendRequests)
                  .HasForeignKey(f => f.RequesterEmail)
                  .HasPrincipalKey(u => u.Email1)
                  .OnDelete(DeleteBehavior.Restrict);

            // Relationship to UserLoginData (Friend)
            entity.HasOne(f => f.Friend)
                  .WithMany(u => u.ReceivedFriendRequests)
                  .HasForeignKey(f => f.FriendEmail)
                  .HasPrincipalKey(u => u.Email2)
                  .OnDelete(DeleteBehavior.Restrict);
        });





    }

}