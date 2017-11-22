using Fasetto.Word.Core;
using System.Security;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class DeviceReservationPage : BasePage<DeviceReservationViewModel>
    {
        public DeviceReservationPage():base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public DeviceReservationPage(DeviceReservationViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}
