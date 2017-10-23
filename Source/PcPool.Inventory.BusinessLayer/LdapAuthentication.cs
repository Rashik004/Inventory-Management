using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace PcPool.Inventory.BusinessLayer
{
    public class ADHelper
    {
        public static bool AuthenticateUser(string domainName, string userName,
            string password)
        {
            bool ret = false;

            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://" + domainName,
                    userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                SearchResult results = null;

                results = dsearch.FindOne();

                ret = true;
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
    }
}
