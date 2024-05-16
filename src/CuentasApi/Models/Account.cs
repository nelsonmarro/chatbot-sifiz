namespace CuentasApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Account
{
  public int Id { get; set; }
  public string AccountNumber { get; set; } = string.Empty;
  public string AccountName { get; set; } = string.Empty;

  [Column(TypeName = "decimal(18,2)")]
  public decimal Balance { get; set; }
  public int UserId { get; set; }
  public User User { get; set; } = null!;
}
