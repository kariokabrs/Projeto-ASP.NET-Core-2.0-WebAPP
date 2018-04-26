using AspNetCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Usuario> Usuarios { get; set; }
    }
}
