using Biblioteca.Data;
using Biblioteca.Data.Model;
using Biblioteca.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using vm = Biblioteca.ViewModel;

namespace Biblioteca.Repository.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private Context _context;
        public GeneroRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Genero.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> Incluir(vm.Genero genero)
        {
            Genero novoGenero = new Genero
            {
                Nome = genero.Nome
            };
            _context.Genero.Add(novoGenero);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Excluir(int id)
        {
            var generoExcluir = await _context.Genero.FindAsync(id);
            if (generoExcluir == null)
            {
                throw new Exception("Gênero não encontrado");
            }
            _context.Entry(generoExcluir).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Alterar(vm.Genero genero)
        {
            var generoAterado = await _context.Genero.FindAsync(genero.Id);
            if (generoAterado == null)
            {
                throw new Exception("Autor não encontrado");
            }
            generoAterado.Nome = genero.Nome;
            _context.Entry(generoAterado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<vm.Genero> BuscaGeneroPorId(int id)
        {
            var genero = await _context.Genero.FindAsync(id);
            return new vm.Genero
            {
                Id = genero.Id,
                Nome = genero.Nome,
            };

        }

        public async Task<IEnumerable<vm.Genero>> ListaGenero()
        {
            return await(from a in _context.Autor.AsNoTracking()
                         select new vm.Genero
                         {
                             Id = a.Id,
                             Nome = a.Nome
                         }
                          ).ToListAsync();
        }

        public async Task<IEnumerable<vm.Genero>> PesquisaGeneroPorNome(string nome)
        {
            return await (from a in _context.Genero.AsNoTracking()
                          where a.Nome.Contains(nome)
                          select new vm.Genero
                          {
                              Id = a.Id,
                              Nome = a.Nome
                          }
                         ).ToListAsync();
        }
    }
}
