using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using UserType = PcPool.Inventory.Model.UserType;

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
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();



#if DEBUG
                var userData=new UserDataProvider();
                var user = Task.Run(() => userData.VerifyUser(Email, pass));
#else
                var adM = new AdfsAuth();
                var user = Task.Run(() => adM.GetUserDetails(Email));
                var isAuthenticated = await Task.Run(() => adM.ValidateCredentials(Email, pass));
                System.Windows.MessageBox.Show(isAuthenticated
                    ? "Successfully Authenticated using ADFS"
                    : "Couldn't Authenticated using ADFS");

                if (!isAuthenticated)
                    return;
#endif
                await user;
                if (user.Result != null)
                {
                    LoggedInUserData.LogInUser(user.Result.UserName,
                        user.Result.FirstName,
                        user.Result.LastName,
                        user.Result.UserType,
                        user.Result.UserId);
                    IoC.Get<ApplicationViewModel>().LoggedInUser = user.Result.FirstName + ' ' + user.Result.LastName;
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Dashboard);
                }

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
