
using Models.InputModels;

namespace Services.Interfaces;
public interface IAccountService
{
    // ii. Register: void
    // iii. Login: string
    void Register(RegisterInputModel user);
    string Login(LoginInputModel user);
}