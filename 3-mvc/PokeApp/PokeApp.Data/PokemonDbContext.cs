using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PokeApp.Data
{

/*
 * three ways to configure the model in EF Core -
 * 1. convention (e.g. if there is a property named "Id" or "<classname>Id",
 *     by default it will be a primary key)
 * 2. fluent API (make method calls in the DbContext.OnModelCreating method)
 * 3. DataAnnotations on the entity classes themselves
 * 
 * #2 is preferred
 */
// Entity Framework Core
// code-first approach steps...
/*
 * 1. have a data access library project separate from the startup application project.
 *    (with a project reference from the latter to the former.)
 * 2. install Microsoft.EntityFrameworkCore.Design
 *    and Microsoft.EntityFrameworkCore.SqlServer to both projects.
 * 3. derive a class from DbContext in the data access project. you want: zero-arg constructor,
 *    DbContextOptions constructor, DbSets, and OnModelCreating override.
 * 4. register the DbContext as a service in the ASP.NET startup project's Startup class, and
 *    add connection string to user secrets.
 * 5. using Git Bash / terminal, from the data access project folder run:
 *    dotnet ef migrations add (name-of-migration) --startup-project (path-to-startup-proj)
 *    dotnet ef database update --startup-project (path-to-startup-proj)
 *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-migrations-add
 * 5. any time you change the structure of the EF configuration, go to step 5.
 */

/*
 * user secrets (right click on mvc project, "Manage user Secrets") should look like:
   {
    "ConnectionStrings": {
      "PokeDb": "connection string goes here"
    }
   }
*/

public class PokemonDbContext : DbContext
{
public PokemonDbContext()
{ }

public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
{ }

// generally one DbSet per intended table / entity
// (but if EF can tell there's a relationship there missing a DbSet, the table
//   and everything else will still be set up)
public DbSet<Pokemon> Pokemon { get; set; }
public DbSet<PokemonType> PokemonType { get; set; }
//public DbSet<PokemonTypeJoin> PokemonTypeJoin { get; set; }
// (there's a DbContext.Set<PokemonTypeJoin>() that would let us get the set anyway)

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Pokemon>(entity =>
    {
        //entity.HasKey(e => e.Id); // unneeded because of convention

        entity.Property(e => e.Id)
            .UseIdentityColumn(); // IDENTITY(1,1)

        entity.Property(e => e.Name)
            .IsRequired() // NOT NULL
            .HasMaxLength(64); // NVARCHAR(64)

        entity.Property(e => e.Height)
            .IsRequired();

        entity.Property(e => e.Weight)
            .IsRequired();
            //.HasColumnType("INT"); // already assumed by convention
    });

    modelBuilder.Entity<PokemonType>(entity =>
    {
        entity.Property(e => e.Id)
            .UseIdentityColumn();

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(64);
    });

    modelBuilder.Entity<PokemonTypeJoin>(entity =>
    {
        // composite key (configured with c# anonymous type)
        entity.HasKey(pt => new { pt.PokemonId, pt.TypeId });

        entity.HasOne(pt => pt.Pokemon) // configure one nav property
            .WithMany(p => p.PokemonTypeJoins) // configure the opposite nav property
            .HasForeignKey(pt => pt.PokemonId) // configure the foreign key property
            .IsRequired() // NOT NULL
            .OnDelete(DeleteBehavior.Cascade); // ON DELETE CASCADE

        entity.HasOne(pt => pt.Type)
            .WithMany(t => t.PokemonTypeJoins)
            .HasForeignKey(pt => pt.TypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    });
}
}
}
