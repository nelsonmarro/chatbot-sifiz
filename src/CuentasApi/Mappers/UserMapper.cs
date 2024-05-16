using AutoMapper;
using CuentasApi.Dto.User;
using CuentasApi.Models;

namespace CuentasApi.Mappers;

public class UserMapper : Profile
{
  public UserMapper() 
  {
    CreateMap<User, UserDto>().ReverseMap();
    CreateMap<CreateUserDto, User>().ReverseMap();
  }
}
