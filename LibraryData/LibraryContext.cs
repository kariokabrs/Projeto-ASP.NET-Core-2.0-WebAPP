using AspNetCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        // Referenciar a classe Usuario no Projeto AspNetCore.Classes e iniciar o SQL Local DB
        // Comando no NuGet: 
        //                  sqllocaldb info ( para checar se tem um SQLLocalDB instalado);
        //                  sqllocaldb create "MyLocalDB" para criar uma instancia do DB chamada MyLocalDB;
        //                  sqllocaldb start "MyLocalDB" para incializar a instancia MyLocalDB;
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Usuario> Usuarios { get; set; }
    }
}
