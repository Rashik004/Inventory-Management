namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class UserListItemDesignModel : UserListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static UserListItemDesignModel Instance => new UserListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserListItemDesignModel()
        {
            UserName = "Admin User";
            CurrentUserType = "Admin";
        }

        #endregion
    }
}
