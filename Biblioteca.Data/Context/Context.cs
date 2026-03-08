using Biblioteca.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class Context : DbContext
    {
        public Context()
        { }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Biblioteca;Integrated Security=True;TrustServerCertificate=True;");

        }
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Mapping.Mapping.Map(modelBuilder);
        }

        public async Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }
        public void Commit()
        {
            base.SaveChanges();
        }

        public void Salvar<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Added;
        }

        public void Alterar<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Modified;
        }

        public void Excluir<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Deleted;
        }
    }
}