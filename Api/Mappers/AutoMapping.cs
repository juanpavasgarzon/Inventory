using Api.Dtos;
using AutoMapper;
using Domain.Commands;

namespace Api.Mappers;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CreateUserDto, CreateUserCommand>();
        CreateMap<CreateProductDto, CreateProductCommand>();
        CreateMap<CreateSupplierDto, CreateSupplierCommand>();
    }
}