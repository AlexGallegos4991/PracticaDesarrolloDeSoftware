using Microsoft.EntityFrameworkCore;
using PracticaDesarrolloDeSoftware.Models;

namespace PracticaDesarrolloDeSoftware.Datos
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
