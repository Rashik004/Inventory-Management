﻿using System;
using System.Collections;
using System.Text;
using System.DirectoryServices.AccountManagement;
using System.Data;
using System.Configuration;
using System.Windows;


namespace PcPool.Inventory.BusinessLayer
{

    public class ADSomeMethods
    {
        #region Variables

        // these two hardcoded variables should be replaced in derived object:
        internal string sDomain = "pool.intra"; // FQDN of Active Directory Domain Name
        internal string sDefaultOU = "DC=pool,DC=intra"; // Root OU in Active Directory for your methods
        // possibly you will find the domain name with code like this (untested):
        // string sDomain = 
        // System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().Name;
        // then it is possible to split the parts of sDefaultOU with code like this (untested):
        // string sDefaultOU = "DC="+sDomain.Split('.')[0]+",DC="+sDomain.Split('.')[1];

        #endregion

        #region Validate Methods

        /// <summary>
        /// Validates the username and password of a given user
        /// </summary>
        /// <param name="sUserName">The username to validate</param>
        /// <param name="sPassword">The password of the username to validate</param>
        /// <returns>Returns True of user is valid</returns>
        public bool ValidateCredentials(string sUserName, string sPassword)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();
            return oPrincipalContext.ValidateCredentials(sUserName, sPassword);
        }

        /// <summary>
        /// Checks if the User Account is Expired
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if Expired</returns>
        public bool IsUserExpired(string sUserName)
        {
            UserPrincipal oUserPrincipal = GetUser(sUserName);
            if (oUserPrincipal.AccountExpirationDate != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if user exists on AD
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if username Exists</returns>
        public bool IsUserExisting(string sUserName)
        {
            if (GetUser(sUserName) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if user account is locked
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true of Account is locked</returns>
        public bool IsAccountLocked(string sUserName)
        {
            UserPrincipal oUserPrincipal = GetUser(sUserName);
            return oUserPrincipal.IsAccountLockedOut();
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// Gets a certain user on Active Directory
        /// </summary>
        /// <param name="sUserName">The username to get</param>
        /// <returns>Returns the UserPrincipal Object</returns>
        public UserPrincipal GetUser(string sUserName)
        {
            try
            {
                PrincipalContext oPrincipalContext = GetPrincipalContext();

                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
                return oUserPrincipal;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets a certain group on Active Directory
        /// </summary>
        /// <param name="sGroupName">The group to get</param>
        /// <returns>Returns the GroupPrincipal Object</returns>
        public GroupPrincipal GetGroup(string sGroupName)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();

            GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName);
            return oGroupPrincipal;
        }

        #endregion


        #region Helper Methods

        /// <summary>
        /// Gets the base principal context
        /// </summary>
        /// <returns>Returns the PrincipalContext object</returns>
        public PrincipalContext GetPrincipalContext()
        {
            try
            {
                PrincipalContext oPrincipalContext = new PrincipalContext
                    (ContextType.Domain, sDomain, sDefaultOU, ContextOptions.Negotiate);
                return oPrincipalContext;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the principal context on specified OU
        /// </summary>
        /// <param name="sOU">The OU you want your Principal Context to 
        //run on</param>
        /// <returns>Returns the PrincipalContext object</returns>
        public PrincipalContext GetPrincipalContext(string sOU)
        {
            try
            {
                PrincipalContext oPrincipalContext =
                    new PrincipalContext(ContextType.Domain, sDomain, sOU, ContextOptions.Negotiate);
                return oPrincipalContext;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }

}
