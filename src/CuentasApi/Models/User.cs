namespace CuentasApi.Models;
public class User
  {
      public int Id { get; set; }
      public string Name { get; set; } = string.Empty;
      public string LastName { get; set; } = string.Empty;
      public string Cedula { get; set; } = string.Empty;
      public string PhoneNumber { get; set; } = string.Empty;
      public string Email { get; set; } = string.Empty;
      public List<Account>? Accounts { get; set; }
  }
