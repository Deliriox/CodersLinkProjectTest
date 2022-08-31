using Domain.Models;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public bool CreateUser(User user);
    }
}
