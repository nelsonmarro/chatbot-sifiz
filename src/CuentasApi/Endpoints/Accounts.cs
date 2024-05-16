namespace CuentasApi.Endpoints;

using AutoMapper;
using Bogus;
using CuentasApi.Data;
using CuentasApi.Dto.Account;
using CuentasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public static class AccountEndpoints
{
  public static RouteGroupBuilder MapAccountEnpoints(this RouteGroupBuilder group)
  {
    group.MapGet("/", GetAllAsync);
    group.MapGet("/{accountId:int}", GetByIdAsync);
    group.MapPost("/", CreateAsync);

    return group;
  }

  private static async Task<Created<AccountDto>> CreateAsync(
    ApplicationDbContext db,
    IMapper mapper,
    int userId,
    CreateAccountDto createAccountDto
  )
  {
    var accountDb = mapper.Map<Account>(createAccountDto);
    accountDb.UserId = userId;

    var faker = new Faker();
    accountDb.Balance = faker.Finance.Amount();
    accountDb.AccountNumber = faker.Finance.Account().ToString();

    await db.Accounts.AddAsync(accountDb);
    await db.SaveChangesAsync();

    var accountDto = mapper.Map<AccountDto>(accountDb);
    return TypedResults.Created($"/{accountDto.Id}", accountDto);
  }

  private static async Task<Results<Ok<AccountDto>, NotFound<string>>> GetByIdAsync(
    ApplicationDbContext db,
    IMapper mapper,
    int userId,
    int accountId
  )
  {
    if (await UserExistsAsync(db, userId))
    {
      return TypedResults.NotFound("No se encontró el usuario");
    }
    if (await db.Accounts.AllAsync(a => a.Id != accountId))
    {
      return TypedResults.NotFound("No se encontró la cuenta con el id dado");
    }

    var accountDb = await db.Accounts.FirstOrDefaultAsync(a =>
      a.UserId == userId && a.Id == accountId
    );
    return TypedResults.Ok(mapper.Map<AccountDto>(accountDb));
  }

  private static async Task<Results<Ok<List<AccountDto>>, NotFound<string>>> GetAllAsync(
    ApplicationDbContext db,
    IMapper mapper,
    int userId
  )
  {
    if (await UserExistsAsync(db, userId))
    {
      return TypedResults.NotFound("No se encontró el usuario");
    }

    return TypedResults.Ok(
      mapper.Map<List<AccountDto>>(await db.Accounts.Where(a => a.UserId == userId).ToListAsync())
    );
  }

  private static async Task<bool> UserExistsAsync(ApplicationDbContext db, int userId) =>
    await db.Users.AllAsync(u => u.Id != userId);
}
