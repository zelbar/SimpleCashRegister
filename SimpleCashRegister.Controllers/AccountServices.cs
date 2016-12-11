using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer;
using SimpleCashRegister.DataAccessLayer.Repositories;
using SimpleCashRegister.Model;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.Services
{
    public class AccountServices
    {
        private static readonly string FailedLoginMessage = "Invalid username or password.";

        public AccountServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private readonly UserRepository _userRepository;
        private bool _loggedIn;
        private bool _asAdmin;

        public bool LoggedIn { get { return _loggedIn; } }
        public bool AsAdmin { get { return _asAdmin; } }

        public bool CreateUser(string username, string password, string displayName, bool admin)
        {
            User user;
            try
            {
                user = _userRepository.GetById(username);
                if (user != null)
                {
                    throw new EntityAlreadyExistsException();
                }
            }
            catch (EntityNotFoundException)
            {
                if (admin)
                    user = new AdminUser(username, password) { DisplayName = displayName };
                else
                    user = new CashierUser(username, password) { DisplayName = displayName };

                _userRepository.Add(user);
                Console.WriteLine("User " + user.DisplayName + " with username \""
                    + user.Id + "\" and password \"" + password + "\" added.");

                return true;
            }
            return false;
        }

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
                _asAdmin = user is AdminUser;

                Console.WriteLine("Successful login!\nWelcome, {0} ({1})\n", user.DisplayName, (_asAdmin) ? "Admin" : "Cashier");
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
