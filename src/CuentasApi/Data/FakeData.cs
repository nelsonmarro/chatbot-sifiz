namespace CuentasApi.Data;

using Bogus;
using Bogus.Extensions.Denmark;
using CuentasApi.Models;

public static class FakeData
{
  public static List<User> Users { get; set; } = [];
  public static List<Account> Accounts { get; set; } = [];

  public static void Init(int count)
  {
    var accountId = 1;
    var accountFaker = new Faker<Account>()
      .RuleFor(a => a.Id, _ => accountId++)
      .RuleFor(a => a.AccountNumber, f => f.Finance.Account().ToString())
      .RuleFor(a => a.AccountName, f => f.Finance.AccountName())
      .RuleFor(a => a.Balance, f => f.Finance.Amount());

    var userId = 1;
    var userFaker = new Faker<User>()
      .RuleFor(u => u.Id, _ => userId++)
      .RuleFor(u => u.Name, f => f.Name.FirstName())
      .RuleFor(u => u.LastName, f => f.Name.LastName())
      .RuleFor(u => u.Cedula, f => f.Person.Cpr())
      .RuleFor(u => u.Email, f => f.Person.Email)
      .RuleFor(u => u.PhoneNumber, f => f.Person.Phone)
      .RuleFor(
        u => u.Accounts,
        (f, u) =>
        {
          _ = accountFaker.RuleFor(a => a.UserId, _ => u.Id);
          var accounts = accountFaker.GenerateBetween(1, 3);
          Accounts.AddRange(accounts);
          return null;
        }
      );

    var users = userFaker.Generate(count);
    Users.AddRange(users);
  }
}
