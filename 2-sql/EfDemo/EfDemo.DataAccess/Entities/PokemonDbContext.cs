using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfDemo.DataAccess.Entities
{
    public partial class PokemonDbContext : DbContext
    {
        public PokemonDbContext()
        {
        }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<PokemonType> PokemonType { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Pokemon__737584F6682AE80D")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<PokemonType>(entity =>
            {
                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonType)
                    .HasForeignKey(d => d.PokemonId)
                    .HasConstraintName("FK__PokemonTy__Pokem__59063A47");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PokemonType)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__PokemonTy__TypeI__59FA5E80");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Type__737584F6FFAC7FAF")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
