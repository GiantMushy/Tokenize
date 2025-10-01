
using Models.InputModels;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations;

public class AccountService : IAccountService
{
    private readonly IAccountRepo _accountRepo;
    public AccountService(IAccountRepo accountRepo)
    {
        _accountRepo = accountRepo;
    }
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