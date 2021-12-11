using System.Linq;
using Comm.DB.Entities;

namespace Comm.Service.User
{
    public class UserService : IUserService
    {
        public bool Login(string username, string password)
        {
            var result = false;
            using (var srv = new CommContext())
            {
                result = srv.Person.Any(user => !user.IsDeleted && user.Username == username && user.Password == password);
            }

            return result;
        }

        public void Register(Person newUser)
        {
            using (var srv = new CommContext())
            {
                srv.Person.Add(newUser);
                srv.SaveChanges();
            }
        }
    }
}