using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Features.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HelpPoint.Infrastructure.Authentication;

public class TokenGenerator(IOptions<JwtSettings> key) : ITokenGenerator
{
    private readonly string _key = key.Value.SecretKey;

    public string GenerateToken(string userName, List<string?> roles, bool isRefreshToken = false)
    {
        var key = Convert.FromBase64String(_key);
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, userName),
            new(ClaimTypes.Name, userName)
        };

        roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role?.Trim() ?? string.Empty)));

        var expirationTime = isRefreshToken ? DateTime.UtcNow.AddHours(4) : DateTime.UtcNow.AddMinutes(5);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expirationTime,
            IssuedAt = DateTime.UtcNow,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String(_key);

        try
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

            if (validatedToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
        catch (SecurityTokenExpiredException)
        {
            throw new UnauthorizedException("Refresh token expired");
        }
        catch
        {
            return null;
        }
    }
}
