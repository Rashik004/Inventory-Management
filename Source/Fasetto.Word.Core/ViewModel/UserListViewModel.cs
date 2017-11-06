using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Core.ViewModelConverter;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class UserListViewModel : BaseViewModel
    {
        private IUserDataProvider _userDataProvider;

        public ObservableCollection<UserListItemViewModel> Items { get; set; }
        //public TYPE Type { get; set; }

        public string Test { get; set; } = "Blah Blah";

        public UserListViewModel()
        {
            _userDataProvider=new UserDataProvider();
            var userList = _userDataProvider.GetAllUsers().Select(ModelToViewModelConverter.UserInfoConverter).ToList();
            Items=new ObservableCollection<UserListItemViewModel>(userList);
        }
    }
}
