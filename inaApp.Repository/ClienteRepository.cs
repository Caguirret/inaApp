using inaApp.Common.interfaces;
using inaApp.Data;
using inaApp.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private readonly ApplicationDbContex _contex;


        public ClienteRepository(ApplicationDbContex contex)
        {
            _contex = contex;
        }

        public async Task<List<Cliente>> ObtenerTodoAsync()
        { 
            return await _contex.Cliente.Where(x => x.Estado).ToListAsync();
        }

        public async Task<Cliente> ObtenerPorIdAsync(int id)
        {
            var cliente = await _contex.Cliente.Where(x => x.IdClient == id && x.Estado).SingleOrDefaultAsync();

            if (cliente == null)
                throw new Exception("Client no encontrado");

            return cliente;
        }

        public async Task<Cliente> CrearAsync(Cliente entity)
        {
            _contex.Cliente.Add(entity);
            await _contex.SaveChangesAsync();

            return entity;
        }

        public async Task<Cliente> ActualizarAsync(Cliente entity)
        {
            _contex.Cliente.Update(entity);
            await _contex.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var cliente = await ObtenerPorIdAsync(id);

            if (cliente == null)
                return false;

            cliente.Estado = false;

            _contex.Cliente.Update(cliente);
            await _contex.SaveChangesAsync();

            return true;
        }

    }
}
