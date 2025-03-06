using HelpPoint.Config;
using HelpPoint.Features.Auth;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Models.Users;

namespace HelpPoint.Features.Users;

public class UserService(IUserRepository userRepository, IUserRolesRepository userRolesRepository, IPasswordHasher passwordHasher) : IUserService
{
    public async Task<User> CreateUser(RegisterDto registerRequest)
    {
        var newUser = new User
        {
            Id = Guid.CreateVersion7(),
            UserName = registerRequest.UserName,
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
            RoleId = AppConstants.RolesConstants.SupportStaffId
        };
        await userRolesRepository.AddAsync(newUserRole);

        return newUser;
    }
}
