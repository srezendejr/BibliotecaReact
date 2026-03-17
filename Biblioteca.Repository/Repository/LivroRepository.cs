using Biblioteca.Data;
using Biblioteca.Data.Model;
using Biblioteca.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using vm = Biblioteca.ViewModel;

namespace Biblioteca.Repository.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly Context _context;
        public LivroRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> Alterar(vm.Livro livro)
        {
            var livroAlterado = await _context.Livro.FindAsync(livro.Id);
            if (livroAlterado != null)
            {
                livroAlterado.IdGenero = livro.IdGenero;
                livroAlterado.IdAutor = livro.IdAutor;
                livroAlterado.Nome = livro.Nome;
                _context.Entry(livroAlterado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<vm.Livro> BuscaLivroPorId(int id)
        {
            var resultado = await (from l in _context.Livro.AsNoTracking()
                                   join a in _context.Autor.AsNoTracking() on l.IdAutor equals a.Id
                                   join g in _context.Genero.AsNoTracking() on l.IdGenero equals g.Id
                                   select new vm.Livro
                                   {
                                       Id = l.Id,
                                       IdAutor = l.IdAutor,
                                       IdGenero = l.IdGenero,
                                       Nome = l.Nome,
                                       NomeGenero = g.Nome,
                                       NomeAutor = a.Nome
                                   }).FirstOrDefaultAsync();
            return resultado ?? new vm.Livro();
        }

        public async Task<bool> Excluir(int id)
        {
            var livroExcluido = await _context.Livro.FindAsync(id);
            if (livroExcluido != null)
            {
                _context.Entry(livroExcluido).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Livro.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> Incluir(vm.Livro livro)
        {
            var livroNovo = new Livro
            {
                IdGenero = livro.IdGenero,
                IdAutor = livro.IdAutor,
                Nome = livro.Nome,
            };
            _context.Livro.Add(livroNovo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<vm.Livro>> ListarLivros()
        {
            return await (from l in _context.Livro.AsNoTracking()
                          join a in _context.Autor.AsNoTracking() on l.IdAutor equals a.Id
                          join g in _context.Genero.AsNoTracking() on l.IdGenero equals g.Id
                          select new vm.Livro
                          {
                              Id = l.Id,
                              IdAutor = l.IdAutor,
                              IdGenero = l.IdGenero,
                              Nome = l.Nome,
                              NomeGenero = g.Nome,
                              NomeAutor = a.Nome
                          }
                          ).ToListAsync();
        }

        public async Task<IEnumerable<vm.Livro>> LivrosPorAutor(int idAutor)
        {
            return await (from l in _context.Livro
                          join a in _context.Autor on l.IdAutor equals a.Id
                          where l.IdAutor == idAutor
                          select new vm.Livro
                          {
                              Id = l.Id,
                              Nome = l.Nome,
                              IdAutor = l.IdAutor,
                              NomeAutor = a.Nome
                          }
                         ).ToListAsync();
        }

        public async Task<IEnumerable<vm.Livro>> LivrosPorGenero(int idGenero)
        {
            return await(from l in _context.Livro
                         join a in _context.Genero on l.IdGenero equals a.Id
                         where l.IdGenero == idGenero
                         select new vm.Livro
                         {
                             Id = l.Id,
                             Nome = l.Nome,
                             IdGenero = l.IdGenero,
                             NomeGenero = a.Nome
                         }
                        ).ToListAsync();
        }
    }
}
