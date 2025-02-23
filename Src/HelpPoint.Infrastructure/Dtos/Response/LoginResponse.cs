namespace HelpPoint.Infrastructure.Dtos.Response;

public class LoginResponse
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
