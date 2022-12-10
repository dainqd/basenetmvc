using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Config;

public partial class MySQLDBContext : DbContext
{
    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<UserInfo> UserInfo { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__Products__B40CC6CDFEF2D15E");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__UserInfo__1788CC4C1F5C1650");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}