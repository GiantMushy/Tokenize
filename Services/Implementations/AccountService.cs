
using Models.InputModels;
using Services.Interfaces;

namespace Services.Implementations;

public class AccountService : IAccountService
{
    // ii. Register: void
    // iii. Login: string
    public void Register(RegisterInputModel user)
    {
        // Registration logic here
        throw new NotImplementedException();
    }
    
    public string Login(LoginInputModel user)
    {
        // Authentication logic here
        throw new NotImplementedException();
    }
}