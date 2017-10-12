using Fasetto.Word.Core;
using System.Security;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class AddItemPage : BasePage<AddItemViewModel>
    {
        public AddItemPage():base()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public AddItemPage(AddItemViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

    }
}
