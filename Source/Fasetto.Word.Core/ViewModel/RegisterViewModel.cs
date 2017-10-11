using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        private IUserDataProvider _userDataProvider;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        //public string Password { get; set; }

        //public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string Designation { get; set; }

        public string Address { get; set; }

        public string Title { get; set; }

        public bool RegisterIsRunning { get; set; }


        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register for a new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RegisterViewModel()
        {
            _userDataProvider=new UserDataProvider();
            // Create commands
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to register a new user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                var user = new User()
                {
                    Address = Address,
                    UserType = UserType.User,
                    LastName = LastName,
                    FirstName = FirstName,
                    Designation = Designation,
                    UserName = UserName,
                    Password = pass,
                    Email = Email,
                    Title = Title
                };
                var t = Task.Run(() => _userDataProvider.AddNewUser(user));
                await t;

            });
        }

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            // Go to register page?
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }
    }
}
