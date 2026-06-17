using AutoMapper;
using inaApp.DTOs.Cliente;
using inaApp.DTOs.Producto;
using inaApp.Entitites;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //DTOs CREATE A ENTITY
            CreateMap<ProductoCreateDTO, Producto>();
            //DTOS UPDATE A ENTITY
            CreateMap<ProductoUpdateDTO, Producto>();
            //ENTITY DTOS RESPONSE
            CreateMap<Producto, ProductoResponseDTO>();

            //MAPPEO de DTOS de Cliente
            //DTOs CREATE A ENTITY
            CreateMap<ClienteCreateDTO, Cliente>();
            //DTOS UPDATE A ENTITY
            CreateMap<ClienteUpdateDTO, Cliente>();
            //ENTITY DTOS RESPONSE
            CreateMap<Cliente, ClienteResponseDTO>();

            CreateMap<Producto, ProductoResponseDTO>()
                .ForMember(
                dest => dest.NombreCategoria,
                opt => opt.MapFrom(src =>
                src.Categoria != null
                ? src.Categoria.Nombre
                : null)
                );
        }
    }
}
