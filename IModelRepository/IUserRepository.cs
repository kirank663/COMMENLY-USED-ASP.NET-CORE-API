using CommenReactProjectAPI.Model;
using System.Collections.Generic;

namespace CommenReactProjectAPI.IModelRepository
{
      public interface IUserRepository
      {
            List<User> GetUserList();

            List<User> GetUserDetailsById(int id);

            int AddUser(User user);

            int DeleteUser(int id);

            int UpdateUser(User user);
            bool IsUserExistIntoTable(string phoneNo , string email);
      }
}
