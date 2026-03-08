using Biblioteca.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data.Mapping
{
    public class Mapping
    {
        public static void Map(ModelBuilder model)
        {
            model.Entity<Autor>()
                .ToTable("Autor")
                 .HasKey(k => k.Id);
            model.Entity<Autor>().Property(p => p.Id).ValueGeneratedOnAdd();

            model.Entity<Genero>()
                .ToTable("Genero")
                 .HasKey(k => k.Id);
            model.Entity<Genero>().Property(p => p.Id).ValueGeneratedOnAdd();

            model.Entity<Livro>()
                .ToTable("Livro")
                 .HasKey(k => k.Id);
            model.Entity<Livro>().Property(p => p.Id).ValueGeneratedOnAdd();

            model.Entity<Livro>()
               .HasOne(b => b.Autor)
               .WithMany(a => a.Livros)
               .HasForeignKey(b => b.IdAutor).OnDelete(DeleteBehavior.NoAction);

            model.Entity<Livro>()
              .HasOne(b => b.Genero)
              .WithMany(a => a.Livros)
              .HasForeignKey(b => b.IdGenero).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
