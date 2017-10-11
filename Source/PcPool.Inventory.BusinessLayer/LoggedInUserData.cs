using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.Inventory.Model;

namespace PcPool.Inventory.BusinessLayer
{
    public class LoggedInUserData
    {
        public static string UserName { get; set; }

        public static string FirstName { get; set; }

        public static string LastName { get; set; }

        public static UserType UserType { get; set; }

        public static int UserId { get; set; }

        public static void LogInUser(string userName, string firstName, string lastName, UserType userType, int userId)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = LastName;
            UserType = userType;
            UserId = userId;
        }

    }
}
