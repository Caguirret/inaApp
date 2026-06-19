using System;
using System.Collections.Generic;
using System.Text;
using inaApp.Entitites;
using Microsoft.EntityFrameworkCore;

namespace inaApp.Data
{
    public class ApplicationDbContex:DbContext
    {

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options): base(options)
        {


        }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        //Fluite api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);

            base.OnModelCreating(modelBuilder);
        }

    }
}
