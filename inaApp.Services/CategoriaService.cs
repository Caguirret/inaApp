using AutoMapper;
using inaApp.Common.Exceptions;
using inaApp.Common.interfaces;
using inaApp.Common.Response;
using inaApp.DTOs.Categoria;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Services
{
    public class CategoriaService : IGenericService<
        CategoriaResponseDTO,
        CategoriaCreateDTO,
        CategoriaUpdateDTO>

    {
        private readonly IGenericRepository<Categoria> _categoriaRepo;
        private readonly IMapper _mappper;

        public CategoriaService(
            IGenericRepository<Categoria> categoriaRepo, IMapper mappper)

        {
            _categoriaRepo = categoriaRepo;
            _mappper = mappper;
        }

        public async Task<Response<CategoriaResponseDTO>>
            CrearAsync(CategoriaCreateDTO entity)
        {
            var categorias = await _categoriaRepo.ObtenerTodoAsync();

            bool existe = categorias.Any(c =>
            c.Nombre.ToLower() == entity.Nombre.ToLower());

            if (existe)
            {
                throw new Exception(
                    $"La cateogira {entity.Nombre} Ya existe");
            }

            var nuevaCategoria =
                _mappper.Map<Categoria>(entity);

            nuevaCategoria.Estado = true;
            nuevaCategoria.FechaCreacion = DateTime.Now;

            var CategoriaCreada = await _categoriaRepo.CrearAsync(nuevaCategoria);

            return new Response<CategoriaResponseDTO>
            {
                Data = _mappper.Map<CategoriaResponseDTO>(CategoriaCreada),
                Message = "Categoria Creada existosamente",
                Success = true

            };
        }

        public async Task<Response<CategoriaResponseDTO>>
            ActualizarAsync(CategoriaUpdateDTO entity)
        {
            var categorias = await _categoriaRepo.ObtenerTodoAsync();

            bool existe = categorias.Any(c => c.Nombre.ToLower() == entity.Nombre.ToLower()
            && c.IdCategoria != entity.IdCategoria);

            if (existe)
            {
                throw new Exception(
                    "Ya existe una categoria con ese nombre");
            }

            var categoria = await _categoriaRepo.ObtenerPorIdAsync(entity.IdCategoria);

            if (categoria == null)
            {
                throw new NotFoundException(
                    "Catetgoria no encontrada");
            }

            var categoriaActualizar =
                _mappper.Map<Categoria>(entity);

            categoriaActualizar.FechaCreacion = categoria.FechaCreacion;

            var categoriaActualizado = await _categoriaRepo.ActualizarAsync(
                categoriaActualizar);

            return new Response<CategoriaResponseDTO>
            {
                Data = _mappper.Map<CategoriaResponseDTO>(categoriaActualizado),
                Message = "Categoria actualizado correctamente",
                Success = true
            };

        }

        public async Task<Response<bool>>
            EliminarAsync(int id)
        {
            var categoria = await _categoriaRepo.ObtenerPorIdAsync(id);

            if (categoria == null)
            {
                throw new NotFoundException(
                    "Categoria no encontrada");
            }

            var eliminado = await _categoriaRepo.EliminarAsync(id);

            return new Response<bool>
            {
                Data = eliminado,
                Message = eliminado
                ? "Categoria elimianda"
                : "No se pudo eliminar",
                Success = eliminado
            };
        }

        public async Task<Response<CategoriaResponseDTO>>
            ObtenerIdAsync(int id)
        {
            var categoria = await _categoriaRepo.ObtenerPorIdAsync(id);

            if (categoria == null)
            {
                throw new NotFoundException(
                    $"La categoria con el id {id} no existe");
            }

            return new Response<CategoriaResponseDTO>
            {
                Data = _mappper.Map<CategoriaResponseDTO>(
                    categoria),
                Message = "Categoria encontrada",
                Success = true

            };

        }

        public async Task <Response<List<CategoriaResponseDTO>>>ObtenerTodoAsync()
        { 
            var lista = await _categoriaRepo.ObtenerTodoAsync();

            var categorias = _mappper.Map<List<CategoriaResponseDTO>>(lista);

            return new Response<List<CategoriaResponseDTO>>
            {
                Data = categorias,
                Message = "Lista de categorias obtenidas con exito",
                Success = true
            };
        }
    }
}

