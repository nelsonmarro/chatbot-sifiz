namespace CuentasApi.Endpoints;

using AutoMapper;
using CuentasApi.Data;
using CuentasApi.Dto.User;
using CuentasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public static class UserEndpoints
{
  public static RouteGroupBuilder MapUserEnpoints(this RouteGroupBuilder group)
  {
    group.MapGet("/", GetAllAsync);
    group.MapGet("/{id:int}", GetByIdAsync);
    group.MapGet("/by-cedula/{cedula}", GetByCedulaAsync);
    group.MapPost("/", CreateAsync);

    return group;
  }

  private static async Task<Results<NotFound<string>, Ok<UserDto>>> GetByIdAsync(
    ApplicationDbContext db,
    IMapper mapper,
    int id
  )
  {
    if (!await db.Users.AnyAsync(u => u.Id == id))
    {
      return TypedResults.NotFound("No se encontró el cliente con el id dado");
    }

    var userDb = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
    return TypedResults.Ok(mapper.Map<UserDto>(userDb));
  }

  private static async Task<Created<UserDto>> CreateAsync(
    ApplicationDbContext db,
    IMapper mapper,
    CreateUserDto dto
  )
  {
    var user = mapper.Map<User>(dto);
    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();

    var userDto = mapper.Map<UserDto>(user);
    return TypedResults.Created($"/users/by-cedula/{userDto.Cedula}", userDto);
  }

  private static async Task<Results<Ok<UserDto>, NotFound<string>>> GetByCedulaAsync(
    ApplicationDbContext db,
    IMapper mapper,
    string cedula
  )
  {
    if (!await db.Users.AnyAsync(u => u.Cedula == cedula))
    {
      return TypedResults.NotFound("No se encontró el cliente con la cédula dada");
    }

    var userDb = await db.Users.FirstOrDefaultAsync(u => u.Cedula == cedula);
    return TypedResults.Ok(mapper.Map<UserDto>(userDb));
  }

  private static async Task<Ok<List<UserDto>>> GetAllAsync(ApplicationDbContext db, IMapper mapper)
  {
    var users = mapper.Map<List<UserDto>>(await db.Users.ToListAsync());
    return TypedResults.Ok(users);
  }
}
