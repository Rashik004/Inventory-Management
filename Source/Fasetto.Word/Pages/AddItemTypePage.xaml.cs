using Fasetto.Word.Core;
using System.Security;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class AddItemTypePage : BasePage<AddItemTypeViewModel>
    {
        public AddItemTypePage():base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public AddItemTypePage(AddItemTypeViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}
