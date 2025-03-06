using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;

namespace HelpPoint.Features.Auth;

public class AuthService(LoginValidator loginValidator,
    IPasswordHasher passwordHasher,
    ITokenGenerator tokenGenerator,
    IUserRepository userRepository
    ) : IAuth
{
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var validationResult = await loginValidator.ValidateAsync(loginRequest);

        if (!validationResult.IsValid)
        {
            throw new HelpPointValidationException(validationResult);
        }

        var user = await userRepository.GetUserByEmailAsync(loginRequest.Email) ??
                   throw new NotFoundException("User not found");

        if (!passwordHasher.Verify(loginRequest.Password, user.PasswordHash))
        {
            throw new UnauthorizedException("Invalid email or password");
        }
        var roles = await userRepository.GetRolesByIdAsync(user.Id) ?? throw new NotFoundException("Roles for user not found");

        if (roles.Count == 0)
        {
            throw new NotFoundException("Roles for user not found");
        }

        var rolesList = roles.Select(x => x?.NormalizedName).ToList();

        var token = tokenGenerator.GenerateToken(user.UserName, rolesList);
        var refreshToken = tokenGenerator.GenerateToken(user.UserName, rolesList, true);

        var response = new LoginResponse
        {
            UserName = user.UserName,
            Email = user.Email,
            Token = token,
            RefreshToken = refreshToken
        };

        return response;
    }
}
