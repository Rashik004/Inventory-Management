using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.DAL;
using PcPool.DAL.Models;
using PcPool.Inventory.BusinessLayer.Interfaces;
using UserType = PcPool.Inventory.Model.UserType;

namespace PcPool.Inventory.BusinessLayer
{
    public  class UserDataProvider: IUserDataProvider
    {
        public Model.User VerifyUser(string userName, string password)
        {
            var ctx=new PcPoolEntities();
            try
            {
                var user = ctx.Users.FirstOrDefault(u => u.UserName == userName /*&& u.Password == password*/);
                return ConvertToModel(user);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Model.User AddNewUser(Model.User user)
        {
            var ctx=new PcPoolEntities();
            try
            {
                 var newUser=ctx.Users.Add(new PcPoolModels.User()
                {
                    UserTypeID = (int) UserType.User,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    UserName = user.UserName,
                    Title = user.Title,
                    Address = user.Address,
                    Designation = user.Designation,
                    Email = user.Email,
                    //Password = user.Password

                });
                ctx.SaveChanges();
                return ConvertToModel(newUser);
            }
            catch (Exception ex)
            {

                return null;
            }
            //return true;
        }

        public List<Model.User> GetAllUsers()
        {
            var ctx=new PcPoolEntities();
            var users = ctx.Users.Select(ConvertToModel).Where(u => u.UserType != UserType.SuperAdmin).ToList();
            return users;
            //return null;
        }

        public void ChangeUserType(int userId)
        {
            using (var ctx=new PcPoolEntities())
            {
                var user = ctx.Users.FirstOrDefault(u => u.UserID == userId);
                if (user == null) return;
                switch (user.UserTypeID)
                {
                    case (int) UserType.Admin:
                        user.UserTypeID = (int) UserType.User;
                        break;
                    case (int) UserType.User:
                        user.UserTypeID = (int) UserType.Admin;
                        break;
                }
                ctx.Users.Attach(user);
                ctx.Entry(user).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        private Model.User ConvertToModel(PcPoolModels.User newUser)
        {
            return newUser == null
                ? null
                : new Model.User()
                {
                    UserName = newUser.UserName,
                    UserId = newUser.UserID,
                    Email = newUser.Email,
                    LastName = newUser.LastName,
                    FirstName = newUser.LastName,
                    Address = newUser.Address,
                    Designation = newUser.Designation,
                    Title = newUser.Title,
                    UserType=(UserType)newUser.UserTypeID
                };
        }
    }
}
