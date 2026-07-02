using System.ComponentModel.DataAnnotations;

public class Users
{
    public int Id { get; init; }
    public string Username { get; set; } = string.Empty;
    [EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime RegistedAtUtc { get; init; }
}