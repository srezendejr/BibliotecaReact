using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data.Model
{
    public class Genero
    {
        public Genero()
        {
            Livros = new List<Livro>();
            Nome = string.Empty;
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
