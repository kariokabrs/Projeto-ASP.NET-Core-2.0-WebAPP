﻿using AspNetCore.Classes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.DBCoontext
{
    public class LibraryContext : DbContext
    {
        // Referenciar a classe Usuario no Projeto AspNetCore.Classes e iniciar o SQL Local DB
        // Comando no NuGet: 
        //                  sqllocaldb info ( para checar se tem um SQLLocalDB instalado);
        //                  sqllocaldb create "MyLocalDB" para criar uma instancia do DB chamada MyLocalDB;
        //                  sqllocaldb start "MyLocalDB" para incializar a instancia MyLocalDB;
        //Para alterar a migração, caso altere seu POCO e já atualziada no BD, use o comando com o nome da migração: update-database "Initial Migration"
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //	Customize	the	ASP.NET	Identity	model	and	override	the	d efaults	if	needed.								
            //	For	example,	you	can	rename	the	ASP.NET	Identity	table	names	and	more.								
            //	Add	your	customizations	after	calling	base.OnModelCreat ing(builder);				
        }
    }
}
