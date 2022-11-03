using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using WebApiLibrary.Models;

namespace WebApiLibrary
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
