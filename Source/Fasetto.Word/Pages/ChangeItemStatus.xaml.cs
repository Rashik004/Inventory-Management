using Fasetto.Word.Core;
using System.Security;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class ChangeItemStatus : BasePage<ChangeItemStatusViewModel>
    {
        public ChangeItemStatus():base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public ChangeItemStatus(ChangeItemStatusViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
