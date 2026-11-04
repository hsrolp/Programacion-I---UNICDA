// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRUD_PERSONAS.Data
{
    public class AppDbContextFactory
        : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=CRUD_PERSONAS;Integrated Security=True;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
