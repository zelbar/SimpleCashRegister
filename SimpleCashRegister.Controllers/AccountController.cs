using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DAL;
using SimpleCashRegister.DAL.Repositories;
using SimpleCashRegister.Model;


namespace SimpleCashRegister.Controllers
{
    public class AccountController
    {
        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private readonly UserRepository _userRepository;

        public void Login(string[] args)
        {
            var username = args[1];
            var password = args[2];
            var passwordHash = password.GetHashCode();

            User user = default(User);
            try
            {
                user = _userRepository.GetById(username);
            }
            catch (EntityNotFoundException)
            {
                // replace with decent view;
                Console.WriteLine("Invalid username or password");
            }

            if (user.PasswordHash == passwordHash)
            {
                Console.WriteLine("Successful login");
            }
        }
    }
}
