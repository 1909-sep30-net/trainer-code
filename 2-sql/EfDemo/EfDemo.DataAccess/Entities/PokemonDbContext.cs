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
                    .HasName("UQ__Pokemon__737584F6521F3A85")
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PokemonTy__Pokem__4F7CD00D");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PokemonType)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PokemonTy__TypeI__5070F446");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Type__737584F66DEDF5BC")
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
