using System;
using System.Linq;
using AdoNetConnected;
using EfDemo.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.App
{
    class Program
    {
        // Entity Framework Core
        // database-first approach steps...
        /*
         * 1. have a data access library project separate from the startup application project.
         *    (with a project reference from the latter to the former).
         * 2. install Microsoft.EntityFrameworkCore.Design and Microsoft.EntityFrameworkCore.SqlServer
         *    to both projects.
         * 3. using Git Bash / terminal, from the data access project folder run (split into several lines for clarity):
         *    dotnet ef dbcontext scaffold <connection-string-in-quotes>
         *      Microsoft.EntityFrameworkCore.SqlServer
         *      --startup-project <path-to-startup-project-folder>
         *      --force
         *      --output-dir Entities
         *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold
         *    (if you don't have dotnet ef installed, run: "dotnet tool install --global dotnet-ef")
         *    (this will fail if your projects do not compile)
         * 4. delete the DbContext.OnConfiguring method from the scaffolded code.
         *    (so that the connection string is not put on the public internet)
         * 5. any time you change the structure of the tables (DDL), go to step 3.
         */

        static void Main(string[] args)
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<PokemonDbContext> options = new DbContextOptionsBuilder<PokemonDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new PokemonDbContext(options);

            DisplayPokemon(context);
        }

        static void DisplayPokemon(PokemonDbContext context)
        {
            foreach (Pokemon pokemon in context.Pokemon)
            {
                string types = string.Join(", ", pokemon.PokemonType.Select(pt => pt.Type.Name));
                if (types.Length == 0)
                {
                    types = "[none]";
                }
                Console.WriteLine($"Pokemon {pokemon.Name} (type {types})");
            }
        }
    }
}
