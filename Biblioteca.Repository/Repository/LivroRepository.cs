using Biblioteca.Data;
using Biblioteca.Data.Model;
using Biblioteca.Repository.Interface;
using vm=Biblioteca.ViewModel;

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

        public async Task<bool> Incluir(vm.Livro livro)
        {
            var livroNovo = new Livro { 
                IdGenero = livro.IdGenero,
                IdAutor = livro.IdAutor,
                Nome = livro.Nome,
            };
            _context.Livro.Add(livroNovo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
