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
        private static readonly string FailedLoginMessage = "Invalid username or password.";

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private readonly UserRepository _userRepository;
        private bool _loggedIn;
        private bool _asAdmin;

        public bool LoggedIn { get { return _loggedIn; } }
        public bool AsAdmin { get { return _asAdmin; } }

        public bool Login(string username, string password)
        {
            var passwordHash = password.GetHashCode();
            bool success = false;

            User user = default(User);
            try
            {
                user = _userRepository.GetById(username);
            }
            catch (EntityNotFoundException)
            {
                // replace with decent view;
                Console.WriteLine(FailedLoginMessage);
                return false;
            }

            if (user.PasswordHash == passwordHash)
            {
                _loggedIn = true;

                if (typeof(User) == typeof(AdminUser))
                    _asAdmin = true;
                else
                    _asAdmin = false;

                Console.WriteLine("Successful login!\nWelcome, {0}\n", user.DisplayName);
                success = true;
            }
            else
            {
                Console.WriteLine(FailedLoginMessage);
            }

            return success;
        }
    }
}
