using inaApp.Common.interfaces;
using inaApp.Data;
using inaApp.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class CategoriaRepository : IGenericRepository<Categoria>
    {
        private readonly ApplicationDbContex _contex;
        public CategoriaRepository(ApplicationDbContex contex)
        {
            _contex = contex;
        }
        public async Task<Categoria> CrearAsync(Categoria entity)
        {
            _contex.Categorias.Update(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }

        public async Task<Categoria> ActualizarAsync(Categoria entity)
        {
            _contex.Categorias.Update(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var categoria = await ObtenerPorIdAsync(id);
            if (categoria == null)
                return false;

            categoria.Estado = false;
            _contex.Categorias.Update(categoria);
            await _contex.SaveChangesAsync();
            return true;

        }

        public async Task<List<Categoria>> ObtenerTodoAsync()
        {
            return await _contex.Categorias
                .AsNoTracking()
                .Where(c => c.Estado == true)
                .ToListAsync();
        }

        public async Task<Categoria> ObtenerPorIdAsync(int id)
        {
            return await _contex.Categorias
                .Where(c => c.IdCategoria == id &&
                c.Estado == true)
                .SingleOrDefaultAsync();
        }
    }
}

