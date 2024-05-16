namespace CuentasApi.Mappers;

using AutoMapper;
using CuentasApi.Dto.Account;
using CuentasApi.Models;

public class AccountMapper : Profile
{
  public AccountMapper()
  {
    CreateMap<Account, AccountDto>();
    CreateMap<CreateAccountDto, Account>();
  }
}
