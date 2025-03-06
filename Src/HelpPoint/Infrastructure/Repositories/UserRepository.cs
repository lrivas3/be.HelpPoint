using HelpPoint.Features.Auth;
using HelpPoint.Infrastructure.DataBase;
using HelpPoint.Infrastructure.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace HelpPoint.Infrastructure.Repositories;

public class UserRepository(HelpPointDbContext context) : IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string email)
        => await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

    public async Task<List<Roles>> GetRolesByIdAsync(Guid userId)
        => await context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Join(context.Roles,
                userRoles => userRoles.RoleId,
                roles => roles.Id,
                (userRoles, roles) => roles)
            .AsNoTracking()
            .ToListAsync();

    public async Task<User> AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public Task<User?> GetUserByUserNameAsync(string userName) =>
        context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == userName);
}
