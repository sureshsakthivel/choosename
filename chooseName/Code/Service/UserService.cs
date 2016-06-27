using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
  using chooseName.Code.Model;
using chooseName.Code.DAL;
namespace chooseName.Code.Service
{
    public class UserService
    {
        UserDAL userDAL = null;

        public void Save(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentException("user is empty");

                if (String.IsNullOrEmpty(user.Name))
                    throw new ArgumentException("user name is empty");


                if (String.IsNullOrEmpty(user.Password))
                    throw new ArgumentException("user password is empty");

                if (String.IsNullOrEmpty(user.EmailId))
                    throw new ArgumentException("user EmailId is empty");

                userDAL = new UserDAL();
                userDAL.Insert(user);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public User GetUser(int userId)
        {
            if (userId<=0)
                throw new ArgumentException("user id is empty");

            userDAL = new UserDAL();
            List<User> users = userDAL.Search(userId);
            return (users != null && users.Count > 0) ? users.FirstOrDefault() : null;
        }
        public List<User> GetUsers()
        {
            userDAL = new UserDAL();
            return userDAL.Search();
        }
    }
}