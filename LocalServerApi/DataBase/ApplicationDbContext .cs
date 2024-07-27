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
    public DbSet<UserLoginData> UserLoginData { get; set; }
    public DbSet<UserLoginRegister> UserLoginRegister { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure UserRegisterData
        modelBuilder.Entity<UserRegisterData>(entity =>
        {
            entity.HasKey(e => e.IdRegister);
            entity.Property(e => e.Granttype).IsRequired();
            entity.Property(e => e.Firstname).IsRequired();
            entity.Property(e => e.Lastname).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.ClientId).IsRequired();
            entity.HasOne(e => e.UserLoginRegister)
                  .WithOne(ulr => ulr.UserRegisterData)
                  .HasForeignKey<UserLoginRegister>(ulr => ulr.IdRegister);
        });

        // Configure UserLoginData
        modelBuilder.Entity<UserLoginData>(entity =>
        {
            entity.HasKey(e => e.IdLogin);
            entity.Property(e => e.Granttype).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.ClientId).IsRequired();
            entity.HasOne(e => e.UserLoginRegister)
                  .WithOne(ulr => ulr.UserLoginData)
                  .HasForeignKey<UserLoginRegister>(ulr => ulr.IdLogin);
        });

        // Configure UserLoginRegister
        modelBuilder.Entity<UserLoginRegister>(entity =>
        {
            entity.HasKey(e => e.IdLoginRegister);
            entity.HasOne(e => e.UserLoginData)
                  .WithOne()
                  .HasForeignKey<UserLoginRegister>(ulr => ulr.IdLogin);
            entity.HasOne(e => e.UserRegisterData)
                  .WithOne()
                  .HasForeignKey<UserLoginRegister>(ulr => ulr.IdRegister);
        });
    }
}
