using HelpPoint.Infrastructure.Models.Users;

namespace HelpPoint.Features.Auth;

public interface IUserRepository
{
    public Task<bool>        UserExists(string username);
    public Task<bool>        EmailExists(string email);
    public Task<User?>       GetUserByEmailAsync(string email);
    public Task<List<Roles>> GetRolesByIdAsync(Guid userId);
    public Task<User>        AddAsync(User user);
    public Task<User?> GetUserByUserNameAsync(string userName);
}
