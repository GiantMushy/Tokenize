using Models.Dtos;
using Models.InputModels;

namespace Repositories.Interfaces;
public interface IAccountRepo
{
    void Register(RegisterInputModel registerInputModel, string hashedPassword);
    UserDto GetUser(string email, string password);
}