using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Config;
using HelpPoint.Features.Auth;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Models.Users;

namespace HelpPoint.Features.Users;

public class UserService(IUserRepository userRepository,
    IUserRolesRepository userRolesRepository,
    ICurrentUserAccessor currentUserAccessor,
    IPasswordHasher passwordHasher) : IUserService
{
    public async Task<User?> CreateUser(RegisterDto registerRequest)
    {
        var userExists = await userRepository.UserExists(registerRequest.UserName);
        var emailExists = await userRepository.EmailExists(registerRequest.UserName);
        if (userExists)
        {
            throw new UserConflictException("Usuario no disponible");
        }
        if (emailExists)
        {
            throw new UserConflictException("Email no disponible");
        }

        var newUser = new User
        {
            Id = Guid.CreateVersion7(),
            UserName = registerRequest.UserName,
            Name = registerRequest.Name,
            LastName = registerRequest.LastName,
            Email = registerRequest.Email,
            EmailConfirmed = false,
            PhoneNumber = registerRequest.PhoneNumber,
            LockOutEnd = DateTime.UtcNow,
            LockOutEnabled = false,
            AccessFailedCount = 0,
            PasswordHash = passwordHasher.HashPassword(registerRequest.Password),
            ManagerId = null
        };

        await userRepository.AddAsync(newUser);

        var newUserRole = new UserRoles
        {
            UserId = newUser.Id,
            RoleId = AppConfigConstants.RolesConstants.SupportStaffId
        };
        await userRolesRepository.AddAsync(newUserRole);

        return newUser;
    }

    public async Task<UserProfileResponse> GetUserProfile()
    {
        var currentuser = currentUserAccessor.GetCurrentUsername();
        var user = await userRepository.GetUserByUserNameAsync(currentuser);
        if (user == null)
        {
            throw new NotFoundException("Usuario no encontrado: "+ currentuser);
        }

        var userRoles = await userRepository.GetRolesByIdAsync(user.Id);

        var response = new UserProfileResponse
        {
            Id = user.Id.ToString(),
            Role = userRoles.FirstOrDefault()?.NormalizedName,
            UserName = user.UserName,
            Name = user.Name + " " + user.LastName,
            Email = user.Email,
            Avatar = CreateAvatarLetters(user.Name, user.LastName)
        };

        return response;
    }

    private static string CreateAvatarLetters(string name, string lastname) =>
        string.Concat(name.AsSpan(0, 1), lastname.AsSpan(0, 1))
            .ToUpper(System.Globalization.CultureInfo.CurrentCulture);
}

public class UserProfileResponse
{
    public required string Id { get; set; }
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public string? Role { get; set; }

    public required string Email { get; set; }
    public required string Avatar { get; set; }
}
