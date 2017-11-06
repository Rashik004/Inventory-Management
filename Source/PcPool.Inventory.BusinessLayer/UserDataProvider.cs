using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.DataAccessLayer.PcPoolDBaseModel;
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
                var user = ctx.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
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
                 var newUser=ctx.Users.Add(new User()
                {
                    UserTypeId = (int) UserType.User,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    UserName = user.UserName,
                    Title = user.Title,
                    Address = user.Address,
                    Designation = user.Designation,
                    Email = user.Email,
                    Password = user.Password

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
            var users = ctx.Users.Select(ConvertToModel).ToList();
            return users;
            //return null;
        }

        private Model.User ConvertToModel(User newUser)
        {
            return newUser == null
                ? null
                : new Model.User()
                {
                    UserName = newUser.UserName,
                    UserId = newUser.UserId,
                    Email = newUser.Email,
                    LastName = newUser.LastName,
                    FirstName = newUser.LastName,
                    Address = newUser.Address,
                    Designation = newUser.Designation,
                    Title = newUser.Title
                };
        }
    }
}
