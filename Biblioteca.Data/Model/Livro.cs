using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data.Model
{
    public class Livro
    {
        public Livro() { 
            Nome =string.Empty;
        }
        public int Id { get; set;  }
        public string Nome { get; set; }
        public int IdGenero { get; set; }
        public int IdAutor {  get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
