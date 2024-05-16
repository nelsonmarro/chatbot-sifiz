namespace CuentasApi.Dto.Account;

public class AccountDto
{
	public int Id { get; set; }
	public string AccountNumber { get; set; } = string.Empty;
	public string AccountName { get; set; } = string.Empty;
	public decimal Balance { get; set; }
	public int UserId { get; set; }
}
