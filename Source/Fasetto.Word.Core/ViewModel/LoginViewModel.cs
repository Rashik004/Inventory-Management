using System.Threading.Tasks;
using System.Windows.Input;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private IUserDataProvider _userDataProvider;

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

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
        public LoginViewModel(/*IUserDataProvider userDataProvider*/)
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
            _userDataProvider = new UserDataProvider();
            //_userDataProvider = userDataProvider;
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                var userDataProvider= new UserDataProvider();
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                var user = userDataProvider.VerifyUser(Email, pass);
                LoggedInUserData.LogInUser(user.UserName,user.FirstName,user.LastName,(UserType)user.UserTypeId,user.UserId);

                await Task.Delay(1000);

                // Go to chat page
                if (user != null)
                {
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Dashboard);
                }

                //var email = Email;

                //// IMPORTANT: Never store unsecure password in variable like this
            });
        }

        private void TestMethod()
        {
            var inventoryData=new InventoryDeviceProvider();
            var ast=inventoryData.GetAll();
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            // Go to register page?
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }
    }
}
