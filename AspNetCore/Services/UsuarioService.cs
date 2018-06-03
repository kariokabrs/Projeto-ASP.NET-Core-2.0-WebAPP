using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCore.Classes;
using AspNetCore.DBCoontext;
using AspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Services
{
    public class UsuarioService : IUsuarioService
    {

        // Dependecy Injection Pattern.
        // Declarar um readonly private e carregar no contrutor desta classe. 
        private readonly LibraryContext _context;

        public UsuarioService(LibraryContext context)
        {
            //DI Pattern no construtor dessa classe para inicializar a classe LibraryContext usada para manipular os dados no BD na DBSet Usuarios
            _context = context;
        }

        // Metodo Select do GET do UsuarioController
        public async Task<IQueryable<Usuario>> GetUsuariosAsync()
        {
            // Select da DbSet Usuarios da LibraryContext _context
            // Como vai haver filtro eu crio uma colecion generci Iqueryble pois o filtro será feito no database e não no cliente. 
            // List<Usuario> items = await _context.Usuarios.Take(10).ToListAsync();
            // Usado o AsNoTracking para ganahr performance em casos apenas de leitura de dados sem precisar ser trackeado. 
            List<Usuario> items = await _context.Usuarios.AsNoTracking().TakeLast(10).OrderBy(c => c.Nome).ToListAsync();

            return items.AsQueryable();
        }

        // Método Insert do POST do UsuarioController
        public async Task<bool> AddItemAsync(UsuarioModel novoUsuario)
        {
            
            Usuario entity = new Usuario
            {
                Nome = novoUsuario.Nome,
                Sobrenome = novoUsuario.Sobrenome,
                DiaCadastro = DateTimeOffset.Now.AddDays(3)
            };

            //para segurar a execução de salvar da chamada Insert do Library Context para ver o icone do botão progress funcionando. 
            //Thread.Sleep(5000);

            // Neste momento do Add, o ID já é gerado então posso trackear e pegar o valor. 
            _context.Usuarios.Add(entity); // Added State. Ñão foi para o banco de dados ainda. 

            _context.Entry(entity).State = EntityState.Added; //Added State. Outra maneira de fazer. 

            // Insert da DbSet Usuarios da LibraryContext
            int saveResult = await _context.SaveChangesAsync(); // Agora sim os dados do context vai para o banco de dados com esta chamada SaveChanges. 

            // O valor do ID gerado pelo Added State. 
            int myUsuarioId = entity.Id;
            return saveResult == 1;
        }

    }

}

