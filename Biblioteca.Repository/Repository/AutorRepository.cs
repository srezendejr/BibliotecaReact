using Biblioteca.Data;
using Biblioteca.Data.Model;
using Biblioteca.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using vm = Biblioteca.ViewModel;

namespace Biblioteca.Repository.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private Context _context;
        public AutorRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> Alterar(vm.Autor autor)
        {
            var autorAlterado = await _context.Autor.FindAsync(autor.Id);
            if (autorAlterado == null)
            {
                throw new Exception("Autor não encontrado");
            }
            autorAlterado.Nome = autor.Nome;
            _context.Entry(autorAlterado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<vm.Autor> BuscaAutorPorId(int id)
        {
            var autor = await _context.Autor.FindAsync(id);
            return new vm.Autor
            {
                Id = autor.Id,
                Nome = autor.Nome,
            };
        }

        public async Task<bool> Excluir(int id)
        {
            var autorExcluir = await _context.Autor.FindAsync(id);
            if (autorExcluir == null)
            {
                throw new Exception("Autor não encontrado");
            }
            _context.Entry(autorExcluir).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Autor.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> Incluir(vm.Autor autor)
        {
            var autorNovo = new Autor
            {
                Nome = autor.Nome
            };
            _context.Autor.Add(autorNovo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<vm.Autor>> ListaAutor()
        {
            return await (from a in _context.Autor.AsNoTracking()
                          select new vm.Autor
                          {
                              Id= a.Id,
                              Nome= a.Nome
                          }
                          ).ToListAsync();
        }

        public async Task<IEnumerable<vm.Autor>> PesquisaAutorPorNome(string nome)
        {
            return await (from a in _context.Autor.AsNoTracking()
                          where a.Nome.Contains(nome)
                          select new vm.Autor
                          {
                              Id = a.Id,
                              Nome = a.Nome
                          }
                         ).ToListAsync();
        }
    }
}
