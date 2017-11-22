using Fasetto.Word.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasetto.Word
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class ApplicationPageHelpers
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            var sd = viewModel as LoginViewModel;
            // Find the appropriate page
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                case ApplicationPage.Dashboard:
                    return new DashBoard(viewModel as DashboardViewModel
                        );

                case ApplicationPage.AddItem:
                    return new AddItemPage(viewModel as AddItemViewModel);
                
                case ApplicationPage.ChangeStatus:
                    return new ChangeItemStatus(viewModel as ChangeItemStatusViewModel);

                case ApplicationPage.AddItemType:
                    return new AddItemTypePage(viewModel as AddItemTypeViewModel);

                case ApplicationPage.DeviceDetails:
                    return new DeviceDetailsPage(viewModel as DeviceDetailsViewModel);

                case ApplicationPage.UserDetails:
                    return new UserDetailsPage(viewModel as UserDetailsViewModel);

                    case ApplicationPage.DeviceReservation:
                        return new DeviceReservationPage(viewModel as DeviceReservationViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            // Find application page that matches the base page
            if (page is DashBoard)
                return ApplicationPage.Dashboard;

            if (page is LoginPage)
                return ApplicationPage.Login;

            if (page is RegisterPage)
                return ApplicationPage.Register;

            if (page is AddItemPage)
                return ApplicationPage.AddItem;

            if (page is ChangeItemStatus)
                return ApplicationPage.ChangeStatus;

            if (page is AddItemTypePage)
                return ApplicationPage.AddItemType;

            if(page is DeviceDetailsPage)
                return ApplicationPage.DeviceDetails;

            // Alert developer of issue
            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
