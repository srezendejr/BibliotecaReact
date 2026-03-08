using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ViewModel
{
    public class Livro
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public int IdGenero { get; set; }
        public string NomeGenero {  get; set; }
        public int IdAutor {  get; set; }
        public string NomeAutor { get; set; }
    }
}
