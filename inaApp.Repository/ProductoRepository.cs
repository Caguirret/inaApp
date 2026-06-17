using inaApp.Common.interfaces;
using inaApp.Entitites;
using inaApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace inaApp.Repository
{
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly ApplicationDbContex _context;
        public ProductoRepository(ApplicationDbContex contex)
        {
            _context = contex;
        }
        public async Task<Producto> ActualizarAsync(Producto entity)
        {
            try
            {
                _context.Producto.Update(entity);
                await _context.SaveChangesAsync();
                return entity;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Producto> CrearAsync(Producto entity)
        {
            try
            { 
                _context.Producto.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> EliminarAsync(int Id)
        {
            try
            {
                var producto = await ObtenerPorIdAsync(Id);
                if (producto == null)
                {
                    return false;
                }
                producto.Estado = false;
                _context.Producto.Update(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Producto>> ObtenerTodoAsync()
        {
            try
            {
                return await _context.Producto
                    .Include(P => P.Categoria)
                    .AsNoTracking()
                    .Where(x => x.Estado == true)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _context.Producto
                    .Include(p => p.Categoria)
                    .Where(x => x.Id == id && x.Estado ==true)
                    .SingleAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
