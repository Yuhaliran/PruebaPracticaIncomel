using Microsoft.EntityFrameworkCore;
namespace Proyecto1.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { }

        public DbSet<Persona> Usuarios { get; set; }


    }
}
