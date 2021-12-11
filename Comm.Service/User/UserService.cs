using System;
using System.Linq;
using AutoMapper;
using Comm.DB.Entities;
using Comm.Model;

namespace Comm.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public bool Login(Model.User.UserLogin registeredUser)
        {
            bool result = false;
            using (var srv = new CommContext())
            {
                bool isFound = srv.Person.Any(
                    user => !user.IsDeleted &&
                    user.Username == registeredUser.Username &&
                    user.Password == registeredUser.Password);
                if (isFound)
                {
                    result = true;
                }
            }
            return result;
        }

        public Common<Model.User.User> Register(Model.User.User newUser)
        {
            var result = new Common<Model.User.User>() { IsSuccess = false };
            try
            {
                var mappedUser = mapper.Map<Person>(newUser);
                using (var srv = new CommContext())
                {
                    mappedUser.Idate = System.DateTime.Now;
                    srv.Person.Add(mappedUser);
                    srv.SaveChanges();
                    result.Entity = mapper.Map<Model.User.User>(mappedUser);
                    result.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                result.ExceptionMessage = "Unexpected error occurred!";
            }
            return result;
        }
    }
}