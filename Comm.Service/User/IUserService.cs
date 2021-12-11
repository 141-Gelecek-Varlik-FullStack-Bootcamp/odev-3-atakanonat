using Comm.DB.Entities;

namespace Comm.Service.User
{
    public interface IUserService
    {
        void Register(Person newUser);
    }
}