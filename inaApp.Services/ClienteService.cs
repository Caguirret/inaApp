using AutoMapper;
using inaApp.Common.Exceptions;
using inaApp.Common.interfaces;
using inaApp.DTOs.Cliente;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using inaApp.Common.Response;

namespace inaApp.Services
{
    public class ClienteService : IGenericService<
        ClienteResponseDTO,
        ClienteCreateDTO,
        ClienteUpdateDTO>
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepo, IMapper mapper)
        {
            _clienteRepository = clienteRepo;
            _mapper = mapper;
        }

        //METODO DE CREAR UN NUEVO CLIENTE DENTRO DEL SISTEMA
        public async Task<Response<ClienteResponseDTO>> CrearAsync(ClienteCreateDTO entity)
        {
            var clientes = await _clienteRepository.ObtenerTodoAsync();

            bool existClient = clientes.Any(c =>
                c.TipoIdentificacion == entity.TipoIdentificacion &&
                c.NumeroIdentificacion == entity.NumeroIdentificacion);

            if (existClient)
            {
                throw new DuplicateClientException(
                    "Ya existe un cliente con esa identificación");
            }

            if (!string.IsNullOrEmpty(entity.Correo) &&
                !entity.Correo.Contains("@"))
            {
                throw new InvalidEmailExceptions(
                    "Correo inválido");
            }
            var nuevoCliente = _mapper.Map<Cliente>(entity);

            nuevoCliente.Estado = true;
            nuevoCliente.FechaCreacion = DateTime.Now;

            var clienteCreado = await _clienteRepository.CrearAsync(nuevoCliente);

            return new Response<ClienteResponseDTO>
            {
                Data = _mapper.Map<ClienteResponseDTO>(clienteCreado),
                Message = "Cliente Creado con exito",
                Success = true
            };
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            var proEliminado = await _clienteRepository.EliminarAsync(id);

            return new Response<bool>
            {
                Data = proEliminado,
                Message = proEliminado
                ? "Cliente eliminado exitosamente"
                : "No se pudo eliminar el cliente",
                Success = proEliminado
            };
        }

        //METODO DE ACTUALIZAR LA LISTA DE LOS CLIENTES
        public async Task<Response<ClienteResponseDTO>> ActualizarAsync(
      ClienteUpdateDTO entity)
        {
            var clientes = await _clienteRepository.ObtenerTodoAsync();

            bool existClient = clientes.Any(c =>
                c.TipoIdentificacion == entity.TipoIdentificacion &&
                c.NumeroIdentificacion == entity.NumeroIdentificacion &&
                c.IdClient != entity.IdClient);

            if (existClient)
            {
                throw new DuplicateClientException(
                    "Ya existe un cliente con esa identificación");
            }

            if (!string.IsNullOrEmpty(entity.Correo) &&
                !entity.Correo.Contains("@"))
            {
                throw new InvalidEmailExceptions(
                    "Correo electrónico inválido");
            }

            var clienteActualizar = _mapper.Map<Cliente>(entity);

            var clienteActualizado = await _clienteRepository.ActualizarAsync(clienteActualizar);

            return new Response<ClienteResponseDTO>
            {
                Data = _mapper.Map<ClienteResponseDTO>(clienteActualizado),
                Message = "Cliente actualizado con exito",
                Success = true
            };
        }

        //METODO PARA OBTENER UN ID ESPECIFICO DE UN CLIENTE 
        public async Task<Response<ClienteResponseDTO>> ObtenerIdAsync(int id)
        {
            var cliente = await _clienteRepository.ObtenerPorIdAsync(id);

            if (cliente == null)
            {
                throw new NotFoundException(
                    $"Cliente con Id {id} no existe");
            }

            return new Response<ClienteResponseDTO>
            {
                Data = _mapper.Map<ClienteResponseDTO>(cliente),
                Message = "Cliente encontrando dentro del sistema",
                Success = true
            };
        }

        //METODO PARA OBTENER LA LISTA COMPLETA DE LOS CLIENTES DENTRO DEL SISTEMA
        public async Task<Response<List<ClienteResponseDTO>>> ObtenerTodoAsync()
        {
            var lista = await _clienteRepository.ObtenerTodoAsync();

            var clientes = _mapper.Map<List<ClienteResponseDTO>>(lista);

            return new Response<List<ClienteResponseDTO>>
            {
                Data = clientes,
                Message = "Lista de clientes obtenida correctamente",
                Success = true
            };
        }
    }
}
