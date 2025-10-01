using Models.Dtos;
using Models.InputModels;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class AccountRepo : IAccountRepo
{
    public void Register(RegisterInputModel model, string hashedPassword)
    {
        // Implementation for registering a user
        throw new NotImplementedException();
    }
    
    public UserDto GetUser(string email, string password)
    {
        // Implementation for retrieving a user
        throw new NotImplementedException();
    }
}