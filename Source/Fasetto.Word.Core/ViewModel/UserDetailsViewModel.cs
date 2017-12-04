using System;
using System.Collections.Generic;
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
    public class UserDetailsViewModel : BaseViewModel
    {
        private IUserDataProvider _userDataProvider;

        public ICommand ChangeuserPermissionCommand { get; set; }

        public UserDetailsViewModel()
        {
            ChangeuserPermissionCommand = new RelayCommand(ChangeUserPermission);

            _userDataProvider = new UserDataProvider();
            Users = _userDataProvider.GetAllUsers();
        }

        private void ChangeUserPermission()
        {
            _userDataProvider.ChangeUserType(SelectedUser.UserId);
            IoC.Application.GoToPage(ApplicationPage.UserDetails);
        }

        public List<User> Users { get; set; }


        private User _selectedUser;
        public User SelectedUser /*{ get; set; }*/
        {
            get { return _selectedUser; }
            set
            {
                this._selectedUser = value;
                if (value == null)
                {
                    ButtonText = "Please Select An User";
                    return;
                }
                ButtonText = value.UserType == UserType.Admin ? "Make Normal User" : "Make Admin User";

            }
        }

        public bool IsFormValid => SelectedUser != null;

        public string ButtonText { get; set; } = "Please Select An User";


    }
}
