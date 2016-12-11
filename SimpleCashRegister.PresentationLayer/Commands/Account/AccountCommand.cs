using SimpleCashRegister.Services;

namespace SimpleCashRegister.PresentationLayer.Commands.Account
{
    public class AccountCommand
    {
        public AccountCommand(AccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        protected readonly AccountServices _accountServices;
    }
}
