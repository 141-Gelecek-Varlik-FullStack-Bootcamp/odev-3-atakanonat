using Comm.DB.Entities;
using Comm.Model;

namespace Comm.Service.User
{
    public interface IUserService
    {
        bool Login(Model.User.UserLogin registeredUser);
        Common<Model.User.User> Register(Model.User.User newUser);
    }
}