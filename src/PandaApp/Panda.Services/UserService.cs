using Panda.Data;
using Panda.Models;
using System.Linq;

namespace Panda.Services
{
    public class UserService : IUserService
    {
        private readonly PandaAppDBContext context;

        public UserService(PandaAppDBContext pandaAppDBContext)
        {
            this.context = pandaAppDBContext;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users.SingleOrDefault(user => (user.Username == username || user.Email == username)
                                                              && user.Password == password);
        }
    }
}
