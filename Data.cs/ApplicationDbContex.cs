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

    }
}
