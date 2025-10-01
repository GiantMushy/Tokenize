using Models.Dtos;
using Models.Entities;
using Models.InputModels;
using Repositories.Contexts;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class AccountRepo : IAccountRepo
{
    private readonly TokenizeDbContext _dbContext;
    public AccountRepo(TokenizeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Register(RegisterInputModel model, string hashedPassword)
    {
        if (_dbContext.Users.Any(u => u.EmailAddress == model.EmailAddress))
        {
            throw new Exception("User with this email already exists.");
        }

        var newUser = new User
        {
            EmailAddress = model.EmailAddress,
            FullName = model.FullName,
            HashedPassword = hashedPassword,
            RegistrationDate = DateTime.UtcNow
        };
        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();
    }

    public UserDto? GetUser(string email, string password)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.EmailAddress == email && u.HashedPassword == password);

        if (user == null)
        {
            throw new Exception("Invalid email or password.");
        }

        return new UserDto
        {
            Id = user.Id,
            EmailAddress = user.EmailAddress,
            FullName = user.FullName
        };
    }
}